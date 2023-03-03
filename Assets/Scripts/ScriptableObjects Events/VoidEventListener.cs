using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class VoidEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEngine.Events.UnityEvent _eventResponse;

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this); 
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this); 
    }

    internal void OnEventOccurred()
    {
        _eventResponse.Invoke();
    }
}
