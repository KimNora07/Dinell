using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Vector3 defaultPosition;

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
        // TODO: 드래그 중일 때 카드의 부모위치 잡기
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        this.transform.position = defaultPosition;
    }
}
