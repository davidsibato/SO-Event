using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Int Game Event")]
public class IntGameEvent : ScriptableObject
{
    private List<EventListener> _observers = new List<EventListener>();
    internal void RegisterObserver(EventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(EventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred(int v)
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(v);
        }
    }
}
