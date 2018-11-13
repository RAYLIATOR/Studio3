﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject characterSelectPanel;
    public GameObject pauseMenuPanel;
    public GameObject youWinPanel;
    public GameObject UI;
    int mainMenuScene;
    int levelScene;
    bool paused;

	void Start ()
    {
        mainMenuScene = 0;
        levelScene = 1;
	}
	
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                Pause();
            }
            else if(paused)
            {
                Resume();
            }
            paused = !paused;
        }
	}

    void Pause()
    {
        pauseMenuPanel.SetActive(true);
    }

    public void YouWin()
    {
        youWinPanel.SetActive(true);
        UI.SetActive(false);
    }

    void Resume()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void PlayGame()
    {

    }      

    public void ExitApplication()
    {
        Application.Quit();
    }
    
    public void MainToChar()
    {
        mainMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
    }

    public void CharToMain()
    {
        characterSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
