using System.Collections.Generic;
using UnityEngine;

public class HorizontalCardHolder : MonoBehaviour
{
    public CardSlot[] cardSlots;

    private void Awake()
    {
        cardSlots = GetComponentsInChildren<CardSlot>();
    }

    public CardSlot EmptyCardSlot()
    {
        foreach(CardSlot slot in cardSlots)
        {
            if(slot.childCard == null)
            {
                return slot;
            }         
        }

        return null;
    }
}
