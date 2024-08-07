using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    
    void Start()
    {
        Destroy(gameObject,4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
