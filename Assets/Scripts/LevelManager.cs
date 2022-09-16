using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 4f; 
    ScoreKeeper scoreKeeper;

    public Leaderboard leaderboard;
    

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        
        SceneManager.LoadScene("GameScene");
        scoreKeeper.ResetScore();
    }
    public void GameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
        int score = scoreKeeper.GetScore();
        StartCoroutine(leaderboard.SubmitScoreRoutine(score));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay); 
        SceneManager.LoadScene(sceneName);
    }

}
