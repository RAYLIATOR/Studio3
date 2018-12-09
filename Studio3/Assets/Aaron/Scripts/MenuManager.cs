using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MenuManager : MonoBehaviour
{
    public Text winnerName;
    public GameObject mainMenuPanel;
    public GameObject characterSelectPanel;
    public GameObject pauseMenuPanel;
    public GameObject youWinPanel;
    public GameObject gameOverPanel;
    public GameObject modeSelectPanel;
    public GameObject UI;
    public GameObject selectPlayer1;
    public GameObject selectPlayer2;
    public GameObject offlineVictoryPanel;
    int mainMenuScene;
    int levelScene;
    bool paused;
    PlayersManager pm;

	void Start ()
    {
        pm = FindObjectOfType<PlayersManager>();
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

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        UI.SetActive(false);
    }

    void Resume()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void PlayGame()
    {

    }      

    public void OfflineVictoryScreen(string winner)
    {
        UI.SetActive(false);
        offlineVictoryPanel.SetActive(true);
        winnerName.text = winner + " wins!";
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
    
    public void MainToMode()
    {
        mainMenuPanel.SetActive(false);
        modeSelectPanel.SetActive(true);
    }

    public void ModeToChar()
    {
        pm.online = true;
        modeSelectPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
    }

    public void CharToMain()
    {
        characterSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ModeToMain()
    {
        modeSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ModeToSP1()
    {
        pm.online = false;
        modeSelectPanel.SetActive(false);
        selectPlayer1.SetActive(true);
    }

    public void SP1ToSP2()
    {
        selectPlayer1.SetActive(false);
        selectPlayer2.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadOfflineScene()
    {
        SceneManager.LoadScene(2);
    }

    public void SelectBlueOfflineP1()
    {
        pm.offlineColorP1 = 1;
    }

    public void SelectRedOfflineP1()
    {
        pm.offlineColorP1 = 2;
    }

    public void SelectGreenOfflineP1()
    {
        pm.offlineColorP1 =3;
    }

    public void SelectYellowOfflineP1()
    {
        pm.offlineColorP1 = 4;
    }
    
    public void SelectBlueOfflineP2()
    {
        pm.offlineColorP2 = 1;
    }

    public void SelectRedOfflineP2()
    {
        pm.offlineColorP2 = 2;
    }

    public void SelectGreenOfflineP2()
    {
        pm.offlineColorP2 = 3;
    }

    public void SelectYellowOfflineP2()
    {
        pm.offlineColorP2 = 4;
    }
}
