using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Scene3()
    {
        SceneManager.LoadScene("ApartmentScene");
    }

     public void Scene4()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

     public void Scene5()
    {
        SceneManager.LoadScene("LessonUI");
    }
}
