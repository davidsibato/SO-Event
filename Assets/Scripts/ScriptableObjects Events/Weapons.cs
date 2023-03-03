using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Event")]
public class Weapons : ScriptableObject
{
    private List<WeaponsEventListener> _observers = new List<WeaponsEventListener>();
    internal void RegisterObserver(WeaponsEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(WeaponsEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred(Weapons_Data weapon)
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(weapon);
        }
    }
}
