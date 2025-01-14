using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceCard", menuName = "Data/Card/Resource")]
public class ResourceCardData : ScriptableObject
{
    // 자원 카드에 관한 데이터
    public string resourceName;                     // 자원의 이름
    public float resourceStrength;                  // 자원의 강도
    public int resourceCount;                       // 소지한 자원 개수
    public EquipmentCardData[] countableToolTypes;  // 캘 수 있는 도구 타입
    public GameObject dropCard;                     // 캤을 때 드롭되는 카드
    public bool isDragEnabled;                      // 드래그가 가능한가?
}
