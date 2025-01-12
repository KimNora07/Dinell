using UnityEditor.Build;
using UnityEngine;

[System.Serializable]
public class ResourceSpawnGroup
{
    public GameObject resourcePrefab;
    public int resourceAmount;
    public int activationDate;
    public float spawnInterval;

    public ResourceSpawnGroup(ResourceSpawnGroup source)
    {
        this.resourcePrefab = source.resourcePrefab;
        this.resourceAmount = source.resourceAmount;
        this.activationDate = source.activationDate;
        this.spawnInterval = source.spawnInterval;
    }
}
