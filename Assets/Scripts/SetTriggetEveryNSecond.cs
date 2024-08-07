using UnityEngine;

public class SetTriggetEveryNSecond : MonoBehaviour
{
    public Animator Animator;
    public float AttackPeriod;
    public string TriggerName = "Attack"; 
    
    private float _timer;
    
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= AttackPeriod)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}