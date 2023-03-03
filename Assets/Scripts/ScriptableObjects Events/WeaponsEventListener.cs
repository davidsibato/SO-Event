using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WeaponUnityEvent : UnityEvent<Weapons_Data> { }
public class WeaponsEventListener : MonoBehaviour
{
    public Weapons gameEvent;
    public WeaponUnityEvent weaponEventResponse = new WeaponUnityEvent();

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this);
    }

    internal void OnEventOccurred(Weapons_Data value)
    {
        weaponEventResponse.Invoke(value);
    }
}
