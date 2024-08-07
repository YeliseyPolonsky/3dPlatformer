using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ListToActivate = new List<ActivateByDistance>();

    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    
    private void Update()
    {
        for (int i = 0; i < ListToActivate.Count; i++)
        {
            ListToActivate[i].CheckDistance(_playerTransform.position);
        }
    }

}
