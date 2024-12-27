using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceCard : MonoBehaviour, IDropHandler
{
    public ResourceCardData resourceCard;

    public string resourceName { get; private set; }                // 자원의 이름
    public float maxResourceStrength { get; private set; }          // 최대 자원의 강도치
    public float currentResourceStrength { get; private set; }      // 현재 자원의 강도치
    public int resourceCount { get; private set; }                  // 소지한 자원 개수

    private void Awake()
    {
        this.resourceName = resourceCard.resourceName;
        this.maxResourceStrength = resourceCard.resourceStrength;
        this.currentResourceStrength = this.maxResourceStrength;
        this.resourceCount = resourceCard.resourceCount;
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        EquipmentCard droppedEquipment = droppedObject.GetComponent<EquipmentCard>();

        if(resourceCard.countableToolType == droppedEquipment.equipmentCardData)
        {
            currentResourceStrength -= droppedEquipment.equipmentStrength;
            droppedEquipment.DecreaseDurability(this);

            if(currentResourceStrength <= 0)
            {
                currentResourceStrength = maxResourceStrength;
                resourceCount--;
            }

            Debug.Log($"남은 강도: {currentResourceStrength} / 남은 자원 수: {resourceCount}");
        }
    }
}
