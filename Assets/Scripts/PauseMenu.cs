using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject notPauseMenu;
    private void Start()
    {
        Time.timeScale = 1;
        notPauseMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        //Pause Menu
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseOrUnpause();
        }
    }

    public void pauseOrUnpause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            notPauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            notPauseMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartScrene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
