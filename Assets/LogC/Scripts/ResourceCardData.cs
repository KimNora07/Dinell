using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceCard", menuName = "Data/Card/Resource")]
public class ResourceCardData : ScriptableObject
{
    // �ڿ� ī�忡 ���� ������
    public string resourceName;                 // �ڿ��� �̸�
    public float resourceStrength;              // �ڿ��� ����
    public int resourceCount;                   // ������ �ڿ� ����
    public EquipmentCardData countableToolType; // Ķ �� �ִ� ���� Ÿ��
}
