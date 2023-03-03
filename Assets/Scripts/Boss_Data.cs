using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName = "Boss Data")]
public class Boss_Data : ScriptableObject
{
    [SerializeField] string _bossName;
    [SerializeField] Sprite _bossImage;
    [SerializeField] Color _bossColor;
    [SerializeField] Element _bossElement;
    [SerializeField] int _bossHealth;
    [SerializeField] Element _bossWeakPoint;
    public enum Element
    {
        fire, rock, water
    }

    

    
    public string BossName => _bossName;
    public int BossHealth => _bossHealth;
    public Element BossAttribute => _bossElement;
    public Element BossWeakPoint => _bossWeakPoint;

    public Color BossColor => _bossColor;
    public Sprite BossImage => _bossImage;
    
}
