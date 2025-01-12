using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceSpawnerScriptable", menuName = "Data/ResourceSpawner")]
public class ResourceSpawnerData : ScriptableObject
{
    public string groupID;
    public int currentActiveResources;

    public ResourceSpawnGroup[] resourceGroups;
}
