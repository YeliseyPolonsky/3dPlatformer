using System;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    [SerializeField] private float _timeScale;
    private float _startFixedDeltaTime;

    void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale *= _timeScale;
            Time.fixedDeltaTime *= _timeScale;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = _startFixedDeltaTime;
        }
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}