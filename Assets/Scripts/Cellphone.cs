using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cellphone : MonoBehaviour
{
    public void changemenuscene(string scenename )
    {
        SceneManager.LoadScene(scenename);
    }

    public void restartGame()
    {
        SaveBetweenScenes.currentLesson = 1;
        SceneManager.LoadScene("Apartment1");
    }
}
