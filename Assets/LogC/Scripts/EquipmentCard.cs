using UnityEngine;

public class EquipmentCard : MonoBehaviour
{
    public EquipmentCardData equipmentCardData;

    public string equipmentName { get; private set; }       // 도구 이름
    public float equipmentStrength { get; private set; }    // 도구의 강도
    public float equipmentDurability { get; private set; }  // 도구의 내구성

    private void Awake()
    {
        this.equipmentName          = equipmentCardData.equipmentName;
        this.equipmentStrength      = equipmentCardData.equipmentStrength;
        this.equipmentDurability    = equipmentCardData.equipmentDurability;
    }

    public void DecreaseDurability(ResourceCard card)
    {
        equipmentDurability -= 5;
        Debug.Log($"{equipmentName}의 남은 내구성: {equipmentDurability}");
    }
}
