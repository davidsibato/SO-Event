using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] AttackEvent OnDamageEnemy;
    [SerializeField] Weapons_Data selectedWeapon;
    [SerializeField] Weapons onWeaponSwap;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void DealDamage()
    {
        OnDamageEnemy.Occurred(selectedWeapon.WeaponDamage, selectedWeapon._element.ToString());
    }

    public void SwapWeapon(Weapons_Data weapon)
    {
        selectedWeapon = weapon;
        onWeaponSwap.Occurred(weapon);
    }
}
