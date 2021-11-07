using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Apartment1 ()
    { 
        SceneManager.LoadScene("Apartment1");
    }

     public void Load()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

     public void LessonUI()
    {
        SceneManager.LoadScene("Lesson UI");
    }

     public void ChooseApartment()
    {
        SceneManager.LoadScene("Choose Apartment");
    }
}
