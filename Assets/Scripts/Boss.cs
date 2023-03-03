using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
     
    [SerializeField] Boss_Data bossData;
    [SerializeField] GameEvent OnAttacked;
    [SerializeField] IntGameEvent OnHealthImpact;
    [SerializeField] GameEvent OnBossKilled;
    [SerializeField] IntGameEvent OnDamage;


    #region Setting up some Prerequisite Stats

    private string bossWeakness;
    private string bossResistance;
    private int bossHP;

    #endregion

    private void Start()
    {
        InitializeBoss(bossData);
    }

    void InitializeBoss(Boss_Data _bData)
    {
        GetComponent<SpriteRenderer>().color = _bData.BossColor;
        bossWeakness = _bData.BossWeakPoint.ToString();
        bossResistance = _bData.BossAttribute.ToString();
        bossHP = _bData.BossHealth;
    }
    public void GetBossData(Level _data)
    {
        bossData = _data.Boss;
        InitializeBoss(bossData);
    }

    public void ReceiveDamage(int _damageDone, string _element)
    {
        int _bonusDamage = 0;
       
        if (_element == bossWeakness)
        {
            _bonusDamage = Mathf.RoundToInt((float)(_damageDone * .5) * Random.Range(1.5f, 3));
            print("Bonus Damage caused: " + _bonusDamage);
        }
        else if (_element == bossResistance)
        {
            CalculateDamage(-_damageDone *1); 
            return;
        }
        OnDamage.Occurred(_damageDone + _bonusDamage);
        CalculateDamage(_damageDone + _bonusDamage);
    }

    private void CalculateDamage(int v)
    {
        bossHP -= v;
        OnHealthImpact.Occurred(bossHP);
        if (bossHP <= 0)
        {
            bossHP = 0;
            OnBossKilled.Occurred();
        }
    }

    private void OnMouseDown()
    {
        OnAttacked.Occurred(); 
    }
}
