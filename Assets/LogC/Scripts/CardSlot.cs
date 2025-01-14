using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public GameObject childCard;

    private void OnEnable()
    {
        if(this.transform.childCount > 0)
        {
            childCard = this.transform.GetChild(0).gameObject;
        }
    }
}
