using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Data")]

public class Level : ScriptableObject
{
    [SerializeField] int level;
    [SerializeField] int levelTime;
    [SerializeField] Sprite background;
    [SerializeField] Boss_Data boss;
    [SerializeField] int pointsTaken;

    
    public int LevelLoaded => level;
    public int LevelTime => levelTime;
    public Sprite Background => background;
    public Boss_Data Boss => boss;
    public int PointsTaken => pointsTaken;
   
}
