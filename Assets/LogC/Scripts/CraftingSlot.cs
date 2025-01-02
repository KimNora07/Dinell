using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject defaultItem;

    private void LateUpdate()
    {
        if (this.transform.childCount == 0)
        {
            item = defaultItem;
        }
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        CardController cardController = eventData.pointerDrag.GetComponent<CardController>();

        if (cardController != null && item == defaultItem)
        {
            cardController.gameObject.transform.SetParent(this.transform);
            cardController.defaultPosition = this.transform.position;
            item = cardController.gameObject;
        }
    }
}
