using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 defaultPosition;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = this.transform.position;      // �߸��� ��ġ�� �ξ��� ��� �ǵ���
        GetComponent<Image>().raycastTarget = false;  
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(eventData.position);   // ���� ������Ʈ�� ��ġ
        currentPosition.z = 0;
        this.transform.position = currentPosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = defaultPosition;
        GetComponent<Image>().raycastTarget = true;
    }
}
