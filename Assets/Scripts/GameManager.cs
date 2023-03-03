using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("List of all Levels Making the Game")]
    List<Level> levelList = new List<Level>();

    [SerializeField] IntGameEvent OnTimeChange; 
    [SerializeField] LevelGameEvent OnLevelChange;
    [SerializeField] GameEvent OnTimeEnded; 

    [SerializeField] GameObject background; 

    private Level currentLevel;

    private void Start()
    {
        // load level 1 I guess. 
        currentLevel = levelList[0];
        OnLevelChange.Occurred(currentLevel);
        StartCoroutine(Timer(currentLevel.LevelTime));
    }

    IEnumerator Timer(int _maxTime)
    {
         
        int timer = 0;
        while (timer < _maxTime)
        {
            yield return new WaitForSeconds(1);
            timer++;
            OnTimeChange.Occurred(timer); 
        }
        OnTimeEnded.Occurred(); 
        yield return null;
    }

    public void LevelWon()
    {
        StopAllCoroutines(); 
        currentLevel = levelList[currentLevel.LevelLoaded];
        OnLevelChange.Occurred(currentLevel); 
    }
    public void BeginBattle()
    {
        StartCoroutine(Timer(currentLevel.LevelTime)); 
    }

    public void ChangeBG()
    {
        background.GetComponent<SpriteRenderer>().sprite = currentLevel.Background; 
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
    }
}
