using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentCard : MonoBehaviour
{
    public EquipmentCardData equipmentCardData;

    public string equipmentName { get; private set; }               // ���� �̸�
    public float equipmentStrength { get; private set; }            // ������ ����
    public float currentEquipmentDurability { get; private set; }   // ������ ������
    public float maxEquipmentDurability { get; private set; }       // ������ ������

    private const float decreaseDurabilityRatio = 0.5f;             // ������ ���� ����

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

        Debug.Log($"{equipmentName}�� ���� ������: {currentEquipmentDurability}");
    }
}
