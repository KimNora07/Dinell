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
        defaultPosition = this.transform.position;      // �߸��� ��ġ�� �ξ��� ��� �ǵ���
        defaultTransform = this.transform.parent;
        
        GetComponent<Image>().raycastTarget = false;
        canvasTransform = FindAnyObjectByType<Canvas>().GetComponent<RectTransform>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(eventData.position);   // ���� ������Ʈ�� ��ġ
        currentPosition.z = 0;
        this.transform.position = currentPosition;
        // TODO: �巡�� ���� �� ī���� �θ���ġ ���
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
