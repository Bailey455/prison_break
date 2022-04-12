using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuPause : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject loseMenu;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);
        escapeMovement.pickups = 0;
        escapeMovement.numberEnemies = 8;
        tokenButtons.tokens = 0;
        tokenButtons.token1.SetActive(false);
        tokenButtons.token2.SetActive(false);
        tokenButtons.token3.SetActive(false);
        tokenButtons.token4.SetActive(false);
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void continueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        escapeMovement.pickups = 0;
        escapeMovement.numberEnemies = 0;
    }
}
