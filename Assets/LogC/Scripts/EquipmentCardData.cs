using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentCard", menuName = "Data/Card/Equipment")]
public class EquipmentCardData : ScriptableObject
{
    // ���� ī�忡 ���� ������
    public string equipmentName;        // ���� �̸�
    public float equipmentStrength;     // ������ ����
    public float equipmentDurability;   // ������ ������
}
