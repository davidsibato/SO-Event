using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Weapon Data")]
public class Weapons_Data : ScriptableObject
{
    [SerializeField] WeaponElement _weaponElement;
    [SerializeField] int _weaponDamage;
    [SerializeField] Sprite _weaponImage;
    [SerializeField] string _weaponName;
    public enum WeaponElement
    {
        Rock, Fire, water
    }
    

    

    public string WeaponName => _weaponName;
    public Sprite WeaponImage => _weaponImage;
    public int WeaponDamage => _weaponDamage;
    public WeaponElement _element => _weaponElement;

    
}
