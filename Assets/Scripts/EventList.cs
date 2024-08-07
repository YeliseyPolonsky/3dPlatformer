using UnityEngine;
using UnityEngine.Events;

public class EventList : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _unityEvents;
    
    public void InvokeEvent(int index)
    {
        _unityEvents[index]?.Invoke();
    }
}
