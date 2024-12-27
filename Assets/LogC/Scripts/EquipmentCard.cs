using UnityEngine;

public class EquipmentCard : MonoBehaviour
{
    public EquipmentCardData equipmentCardData;

    public string equipmentName { get; private set; }       // ���� �̸�
    public float equipmentStrength { get; private set; }    // ������ ����
    public float equipmentDurability { get; private set; }  // ������ ������

    private void Awake()
    {
        this.equipmentName          = equipmentCardData.equipmentName;
        this.equipmentStrength      = equipmentCardData.equipmentStrength;
        this.equipmentDurability    = equipmentCardData.equipmentDurability;
    }

    public void DecreaseDurability(ResourceCard card)
    {
        equipmentDurability -= 5;
        Debug.Log($"{equipmentName}�� ���� ������: {equipmentDurability}");
    }
}
