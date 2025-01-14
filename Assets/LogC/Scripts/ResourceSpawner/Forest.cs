using System.Collections.Generic;
using UnityEngine;

public class Forest : Place
{
    public ResourceSpawnerData resourceSpawnerData;

    public string groupID;
    public int currentActiveResources;
    public ResourceSpawnGroup[] resourceGroups;

    public Dictionary<ResourceCardData, GameObject> resourcePrefabDic;

    [SerializeField] private List<Transform> resourceSlots;

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        ResourceSpawnerDataLoader();

        resourcePrefabDic = new Dictionary<ResourceCardData, GameObject>();

        for(int i = 0; i < resourceGroups.Length; i++)
        {
            if (resourceGroups[i].resourcePrefab == null)
            {
                Debug.LogError("�ڿ�ī�忡 �´� ������Ʈ�� �߰����� ���߽��ϴ�!");
                return;
            }
            resourcePrefabDic.Add(resourceGroups[i].resourcePrefab.GetComponent<ResourceCard>().resourceCard, resourceGroups[i].resourcePrefab);
        }
    }

    public override void ResourceSpawnerDataLoader()
    {
        this.groupID = resourceSpawnerData.groupID;
        this.currentActiveResources = resourceSpawnerData.currentActiveResources;
        this.resourceGroups = resourceSpawnerData.resourceGroups;
    }

    public override void ResourceCardSpawn(ResourceCardData data)
    {
        if(resourcePrefabDic.TryGetValue(data, out GameObject resourcePrefab))
        {
            ResourceSpawnGroup group = System.Array.Find(resourceGroups, rg => rg.resourcePrefab.GetComponent<ResourceCard>().resourceCard == data);

            if(currentActiveResources < resourceSlots.Count)
            {
                foreach (var slot in resourceSlots)
                {
                    if(slot.childCount == 0)
                    {
                        GameObject cardPrefab = Instantiate(resourcePrefab, slot);
                        currentActiveResources++;

                        // ���ҽ� ī�尡 �ı��� �� Ȱ��ȭ�� ī�� �� ���� �̺�Ʈ �߰�
                        cardPrefab.GetComponent<ResourceCard>().OnDestroyResourceCard += () =>
                        {
                            currentActiveResources--;
                        };
                        break;
                    }
                }
            }
        }
    }
}
