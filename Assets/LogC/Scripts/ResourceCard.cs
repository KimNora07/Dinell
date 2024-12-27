using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceCard : MonoBehaviour, IDropHandler
{
    public ResourceCardData resourceCard;

    public string resourceName { get; private set; }                // �ڿ��� �̸�
    public float maxResourceStrength { get; private set; }          // �ִ� �ڿ��� ����ġ
    public float currentResourceStrength { get; private set; }      // ���� �ڿ��� ����ġ
    public int resourceCount { get; private set; }                  // ������ �ڿ� ����

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

            Debug.Log($"���� ����: {currentResourceStrength} / ���� �ڿ� ��: {resourceCount}");
        }
    }
}
