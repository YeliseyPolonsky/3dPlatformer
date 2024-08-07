using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _points;
    
    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_prefab, _points[i].position,_points[i].rotation);
        }
    }
}
