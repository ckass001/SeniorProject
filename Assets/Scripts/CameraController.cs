using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTf;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private PlayerMovement playerm;
    [SerializeField] private AnimationController playerAC;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject notPauseMenu;
    private void Start()
    {
        Time.timeScale = 1;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        notPauseMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        transform.position = new Vector3(playerTf.position.x, playerTf.position.y, transform.position.z);

        //Pause Menu
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseOrUnpause();
        }
    }

    public void pauseOrUnpause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            playerRb.bodyType = RigidbodyType2D.Static;
            playerm.enabled = !playerm.enabled;
            playerAC.enabled = !playerAC.enabled;
            pauseMenu.SetActive(true);
            notPauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            playerRb.bodyType = RigidbodyType2D.Dynamic;
            playerm.enabled = !playerm.enabled;
            playerAC.enabled = !playerAC.enabled;
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
