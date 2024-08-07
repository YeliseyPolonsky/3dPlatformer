using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public Transform Spawner;
    public GameObject Prefab;

    public void Create()
    {
        Instantiate(Prefab, Spawner.position, Spawner.rotation);
    }
}
