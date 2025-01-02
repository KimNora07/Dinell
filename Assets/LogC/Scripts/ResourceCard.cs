using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceCard : MonoBehaviour, IDropHandler
{
    public ResourceCardData resourceCard;

    [HideInInspector] public string resourceName { get; private set; }                // �ڿ��� �̸�
    [HideInInspector] public float maxResourceStrength { get; private set; }          // �ִ� �ڿ��� ����ġ
    [HideInInspector] public float currentResourceStrength { get; private set; }      // ���� �ڿ��� ����ġ
    [HideInInspector] public int resourceCount { get; private set; }                  // ������ �ڿ� ����

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
        CardController cardController = droppedObject.GetComponent<CardController>();

        if(cardController == null || !cardController.isActiveAndEnabled)
        {
            Debug.Log("�巡�װ� �Ұ����� ������Ʈ�Դϴ�!");
            return;
        }

        if(resourceCard.countableToolType == droppedEquipment.equipmentCardData)
        {
            currentResourceStrength -= droppedEquipment.equipmentStrength;
            droppedEquipment.DecreaseDurability(this);

            currentResourceStrength = Mathf.Clamp(currentResourceStrength, 0, maxResourceStrength);
            if (currentResourceStrength == 0)
            {
                currentResourceStrength = maxResourceStrength;
                resourceCount--;
                // TODO: �ڿ� ī�� ����
            }

            Debug.Log($"���� ����: {currentResourceStrength} / ���� �ڿ� ��: {resourceCount}");
        }
    }
}
