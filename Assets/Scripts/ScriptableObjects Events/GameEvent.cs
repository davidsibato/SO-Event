using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private List<VoidEventListener> _observers = new List<VoidEventListener> ();
    internal void RegisterObserver(VoidEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(VoidEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred()
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(); 
        }
    }

    internal void RegisterObserver(EventListener eventListener)
    {
        throw new NotImplementedException();
    }

    internal void UnregisterObserver(EventListener eventListener)
    {
        throw new NotImplementedException();
    }
}
