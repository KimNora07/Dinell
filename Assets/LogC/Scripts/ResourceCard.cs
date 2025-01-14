using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ResourceCard : MonoBehaviour, IDropHandler
{
    public ResourceCardData resourceCard;

    [HideInInspector] public string resourceName { get; private set; }                  // �ڿ��� �̸�
    [HideInInspector] public float  maxResourceStrength { get; private set; }           // �ִ� �ڿ��� ����ġ
    [HideInInspector] public float  currentResourceStrength { get; private set; }       // ���� �ڿ��� ����ġ
    [HideInInspector] public int    resourceCount { get; private set; }                 // ������ �ڿ� ����

    [Header("UI")]
    [SerializeField] private Image      strengthBar;
    [SerializeField] private TMP_Text   countText;

    public delegate void OnResourceCardHandler();
    public event OnResourceCardHandler OnDestroyResourceCard;
    public event OnResourceCardHandler OnDecreaseResource;

    private HorizontalCardHolder cardDeck;

    private void Awake()
    {
        this.resourceName = resourceCard.resourceName;
        this.maxResourceStrength = resourceCard.resourceStrength;
        this.currentResourceStrength = this.maxResourceStrength;
        this.resourceCount = resourceCard.resourceCount;
        strengthBar.fillAmount = this.currentResourceStrength / this.maxResourceStrength;
        countText.text = this.resourceCount.ToString();

        cardDeck = FindAnyObjectByType<HorizontalCardHolder>();

        OnDestroyResourceCard += () => { };
        OnDecreaseResource += () => { DecreaseCardEvent(); };
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        EquipmentCard droppedEquipment = droppedObject.GetComponent<EquipmentCard>();
        CardController cardController = droppedObject.GetComponent<CardController>();

        if (cardController == null || !cardController.isActiveAndEnabled)
        {
            Debug.Log("�巡�װ� �Ұ����� ������Ʈ�Դϴ�!");
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
                    // TODO: �ڿ� ī�� ����
                    OnDecreaseResource?.Invoke();

                    if (this.resourceCount == 0)
                    {
                        Destroy(this.gameObject);
                    }
                }

                Debug.Log($"���� ����: {currentResourceStrength} / ���� �ڿ� ��: {resourceCount}");
                break;
            }
        }
    }

    private void OnDestroy()
    {
        OnDestroyResourceCard?.Invoke();
    }

    private void DecreaseCardEvent()
    {
        CardSlot emptySlot = cardDeck.EmptyCardSlot();
        if (emptySlot == null) return;

        GameObject dropCard = Instantiate(resourceCard.dropCard, emptySlot.transform);
        emptySlot.childCard = dropCard;
    }
}
