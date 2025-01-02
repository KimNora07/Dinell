using UnityEngine;
using UnityEditor;
using System;
using System.Net;
using Unity.VisualScripting;

[CustomEditor(typeof(ItemGrid))]
public class CraftingData : Editor
{
    public override void OnInspectorGUI()
    {
        ItemGrid itemGrid = (ItemGrid)target;

        EditorGUILayout.LabelField("Recipe");
        for(int i = 0; i < 3; i++)
        {
            GUILayout.BeginHorizontal();
            for(int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;
                if(index < itemGrid.cards.Length)
                {
                    itemGrid.cards[index] = (ResourceCard)EditorGUILayout.ObjectField(itemGrid.cards[index], typeof(ResourceCard), false);
                }
            }
      
            GUILayout.EndHorizontal();
        }

        itemGrid.item = (GameObject)EditorGUILayout.ObjectField("Item", itemGrid.item, typeof(GameObject), false);
    }
}

[CreateAssetMenu(fileName = "New ItemGrid", menuName = "Data/ItemGrid")]
public class ItemGrid : ScriptableObject
{
    public ResourceCard[] cards = new ResourceCard[9];
    public GameObject item;
}