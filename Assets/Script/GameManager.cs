using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager Instance;
    public int GameCount = 0;
    public Text Scoretxt;
    public int Score;
    public int TotalGame = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            DontDestroyOnLoad(this.gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameCount > TotalGame)
        {
            GameOver();
        }
        Scoretxt.text = Score.ToString();
    }
    public void GameOver()
    {
        Debug.Log("Game over");
       // RestartScene();
    }
    public void RestartScene()
    {
        Debug.Log("Scene Restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
