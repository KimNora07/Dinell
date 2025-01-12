using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public ResourceSpawnerData resourceSpawnerData;

    public string groupID;
    public int currentActiveResources;
    public ResourceSpawnGroup[] resourceGroups;

    public Dictionary<ResourceCardData, GameObject> resourcePrefabDic;

    [SerializeField] private List<Transform> resourceSlots;

    private void Init()
    {
        ResourceSpawnerDataLoader();

        resourcePrefabDic = new Dictionary<ResourceCardData, GameObject>();

        for(int i = 0; i < resourceGroups.Length; i++)
        {
            if (resourceGroups[i].resourcePrefab == null)
            {
                Debug.LogError("자원카드에 맞는 오브젝트를 발견하지 못했습니다!");
                return;
            }
            resourcePrefabDic.Add(resourceGroups[i].resourcePrefab.GetComponent<ResourceCard>().resourceCard, resourceGroups[i].resourcePrefab);
        }
    }

    private void ResourceSpawnerDataLoader()
    {
        this.groupID = resourceSpawnerData.groupID;
        this.currentActiveResources = resourceSpawnerData.currentActiveResources;
        this.resourceGroups = resourceSpawnerData.resourceGroups;
    }

    private void ResourceCardSpawn(ResourceCardData data)
    {
        if(resourcePrefabDic.TryGetValue(data, out GameObject resourcePrefab))
        {
            ResourceSpawnGroup group = System.Array.Find(resourceGroups, rg => rg.resourcePrefab.GetComponent<ResourceCard>().resourceCard == data);

            if(currentActiveResources <= resourceSlots.Count)
            {      
                foreach(var slot in resourceSlots)
                {
                    if(slot.childCount == 0)
                    {
                        GameObject cardPrefab = Instantiate(resourcePrefab, slot);
                    }
                }
                currentActiveResources++;

                // TODO: 리소스 카드가 파괴될 때 활성화된 카드 수 감소
            }
        }
    }
}
