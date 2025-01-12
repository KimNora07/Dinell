using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Vector3 defaultPosition;
    private Transform defaultTransform;
    private RectTransform canvasTransform;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = this.transform.position;      // 잘못된 위치에 두었을 경우 되돌림
        defaultTransform = this.transform.parent;
        
        GetComponent<Image>().raycastTarget = false;
        canvasTransform = FindAnyObjectByType<Canvas>().GetComponent<RectTransform>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(eventData.position);   // 현재 오브젝트의 위치
        currentPosition.z = 0;
        this.transform.position = currentPosition;
        // TODO: 드래그 중일 때 카드의 부모위치 잡기
        transform.SetParent(canvasTransform);
        transform.SetAsLastSibling();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        this.transform.position = defaultPosition;
        transform.SetParent(defaultTransform);
    }
}
