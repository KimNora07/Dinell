using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingSlotPrefab;

    public CraftingSlot[] craftingSlots;
    public ItemGrid[] itemGrids;

    public Button craftbutton;
    public Transform completeCraftingPostion;

    private void Awake()
    {
        craftbutton.onClick.AddListener(() => { Craft(); });

        craftingSlots = this.gameObject.GetComponentsInChildren<CraftingSlot>();
    }

    public void Craft()
    {
        bool isValid = IsCombinationValid(craftingSlots, itemGrids);
        Debug.Log(isValid);
    }

    public bool IsCombinationValid(CraftingSlot[] craftingSlots, ItemGrid[] itemGrids)
    {
        foreach (var recipe in itemGrids)
        {
            if (craftingSlots.Length != recipe.cards.Length)
            {
                continue;
            }

            bool isValid = true;
            // 각 카드의 위치와 내용을 비교
            for (int i = 0; i < craftingSlots.Length; i++)
            {
                if (craftingSlots[i].item == null ||
                    craftingSlots[i].item.GetComponent<ResourceCard>() == null ||
                    recipe.cards[i] == null)
                {
                    isValid = false;
                    break;
                }

                if (craftingSlots[i].item.GetComponent<ResourceCard>().resourceCard != recipe.cards[i].resourceCard)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                GameObject item = Instantiate(recipe.item, completeCraftingPostion);
                item.transform.position = completeCraftingPostion.position;
                return true;
            }
        }
        return false;
    }
}
