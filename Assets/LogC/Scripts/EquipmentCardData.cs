using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentCard", menuName = "Data/Card/Equipment")]
public class EquipmentCardData : ScriptableObject
{
    // 도구 카드에 관한 데이터
    public string equipmentName;        // 도구 이름
    public float equipmentStrength;     // 도구의 강도
    public float equipmentDurability;   // 도구의 내구성
}
