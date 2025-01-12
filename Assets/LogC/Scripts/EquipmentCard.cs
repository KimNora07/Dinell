using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentCard : MonoBehaviour
{
    public EquipmentCardData equipmentCardData;

    public string equipmentName { get; private set; }               // 도구 이름
    public float equipmentStrength { get; private set; }            // 도구의 강도
    public float currentEquipmentDurability { get; private set; }   // 도구의 내구성
    public float maxEquipmentDurability { get; private set; }       // 도구의 내구성

    private const float decreaseDurabilityRatio = 0.5f;             // 내구성 감소 비율

    [Header("UI")]
    [SerializeField] private Image durabilityBar;

    private void Awake()
    {
        this.equipmentName          = equipmentCardData.equipmentName;
        this.equipmentStrength      = equipmentCardData.equipmentStrength;
        this.maxEquipmentDurability    = equipmentCardData.equipmentDurability;
        this.currentEquipmentDurability = this.maxEquipmentDurability;
        durabilityBar.fillAmount = this.currentEquipmentDurability / this.maxEquipmentDurability;
    }

    public void DecreaseDurability(ResourceCard card)
    {
        currentEquipmentDurability = Mathf.Max(0, currentEquipmentDurability - decreaseDurabilityRatio * ((this.equipmentStrength / card.maxResourceStrength) * card.currentResourceStrength));
        durabilityBar.fillAmount = this.currentEquipmentDurability / this.maxEquipmentDurability;

        if(this.currentEquipmentDurability == 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log($"{equipmentName}의 현재 내구성: {currentEquipmentDurability}");
    }
}
