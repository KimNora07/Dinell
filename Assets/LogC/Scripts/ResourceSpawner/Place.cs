using UnityEngine;

public abstract class Place : MonoBehaviour
{
    public abstract void Init();
    public abstract void ResourceSpawnerDataLoader();
    public abstract void ResourceCardSpawn(ResourceCardData data);
}
