using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 defaultPosition;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = this.transform.position;      // 잘못된 위치에 두었을 경우 되돌림
        GetComponent<Image>().raycastTarget = false;  
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(eventData.position);   // 현재 오브젝트의 위치
        currentPosition.z = 0;
        this.transform.position = currentPosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = defaultPosition;
        GetComponent<Image>().raycastTarget = true;
    }
}
