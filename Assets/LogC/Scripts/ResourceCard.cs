using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ResourceCard : MonoBehaviour, IDropHandler
{
    public ResourceCardData resourceCard;

    [HideInInspector] public string resourceName { get; private set; }                  // 자원의 이름
    [HideInInspector] public float  maxResourceStrength { get; private set; }           // 최대 자원의 강도치
    [HideInInspector] public float  currentResourceStrength { get; private set; }       // 현재 자원의 강도치
    [HideInInspector] public int    resourceCount { get; private set; }                 // 소지한 자원 개수

    [Header("UI")]
    [SerializeField] private Image      strengthBar;
    [SerializeField] private TMP_Text   countText;

    private void Awake()
    {
        this.resourceName = resourceCard.resourceName;
        this.maxResourceStrength = resourceCard.resourceStrength;
        this.currentResourceStrength = this.maxResourceStrength;
        this.resourceCount = resourceCard.resourceCount;
        strengthBar.fillAmount = this.currentResourceStrength / this.maxResourceStrength;
        countText.text = this.resourceCount.ToString();
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        EquipmentCard droppedEquipment = droppedObject.GetComponent<EquipmentCard>();
        CardController cardController = droppedObject.GetComponent<CardController>();

        if(cardController == null || !cardController.isActiveAndEnabled)
        {
            Debug.Log("드래그가 불가능한 오브젝트입니다!");
            return;
        }

        foreach (var countableTool in resourceCard.countableToolTypes)
        {
            if (countableTool == droppedEquipment.equipmentCardData)
            {
                currentResourceStrength = Mathf.Max(0, currentResourceStrength - droppedEquipment.equipmentStrength);
                strengthBar.fillAmount = this.currentResourceStrength / this.maxResourceStrength;

                droppedEquipment.DecreaseDurability(this);

                if (currentResourceStrength == 0)
                {
                    currentResourceStrength = maxResourceStrength;
                    strengthBar.fillAmount = this.currentResourceStrength / this.maxResourceStrength;
                    resourceCount--;
                    countText.text = this.resourceCount.ToString();
                    // TODO: 자원 카드 지급

                    if (this.resourceCount == 0)
                    {
                        Destroy(this.gameObject);
                    }
                }

                Debug.Log($"남은 강도: {currentResourceStrength} / 남은 자원 수: {resourceCount}");
                break;
            }
        }
    }
}
