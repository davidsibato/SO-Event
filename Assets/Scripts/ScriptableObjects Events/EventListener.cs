using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEvent : UnityEvent<int> { }

public class EventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent _EventResponse = new UnityEvent();

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this);
    }

    internal void OnEventOccurred(int value)
    {
        _EventResponse.Invoke(value);
    }
}
