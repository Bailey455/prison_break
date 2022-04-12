using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loseScreen : MonoBehaviour
{
    public GameObject screenLose;

    public void retry()
    {
        screenLose.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);
    }

    public void giveUp()
    {
        screenLose.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
