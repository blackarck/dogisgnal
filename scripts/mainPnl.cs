using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainPnl : MonoBehaviour
{

    Canvas canvas;
    public GameObject mainPanel, pausePnl, gameOverPnl, inGamePnl;  //, aboutPanel, , 
    bool GameIsPaused;
    public Text scoreTxt, gScoreTxt;
    public UnityEngine.UI.Dropdown difficulty;
    // Use this for initialization
    void Start()
    {
        initCanvas();
        GameIsPaused = false;
        //vivek AudioManager.instance.Play("startscreen");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        scoreTxt.text = "Score : " + GameManager.instance.score.ToString();
    }

    public void Resume()
    {
        pausePnl.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {

        pausePnl.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void initCanvas()
    {
        canvas = GetComponent<Canvas>();
       // aboutPanel.SetActive(false);
        gameOverPnl.SetActive(false);
        mainPanel.SetActive(true);
        pausePnl.SetActive(false);
        inGamePnl.SetActive(false);
    }

    public void playbtn()
    {
       //vivek AudioManager.instance.Stop("startscreen");
         AudioManager.instance.Play("button");
        mainPanel.SetActive(false);
        inGamePnl.SetActive(true);
        if (difficulty)
        {
            //  Debug.Log("Difficulty is " + difficulty.options[difficulty.value].text);
            //0=easy 1=medium 2=godmode
            if (difficulty.options[difficulty.value].text.Equals("Medium"))
            {
                GameManager.instance.difficulty = 1;
            }
            if (difficulty.options[difficulty.value].text.Equals("Easy"))
            {
                GameManager.instance.difficulty = 0;
            }
            if (difficulty.options[difficulty.value].text.Equals("God Mode"))
            {
                GameManager.instance.difficulty = 2;
            }
        }
        GameManager.instance.gameOn = true;
        //AudioManager.instance.Play("maintrack");


    }

    public void aboutbtn()
    {
        AudioManager.instance.Play("select");
        mainPanel.SetActive(false);
       // aboutPanel.SetActive(true);
    }

    public void backbtn()
    {
        AudioManager.instance.Play("select");
        mainPanel.SetActive(true);
      //  aboutPanel.SetActive(false);
    }

    public void restartBtn()
    {
         AudioManager.instance.Play("button");
        initCanvas();
        GameManager.instance.InitGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void showGameOver()
    {
       // AudioManager.instance.Play("gameover");
        gScoreTxt.text = "" + GameManager.instance.score.ToString();
        inGamePnl.SetActive(false);
        gameOverPnl.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        GameIsPaused = false;
    }
}
