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

    public void Apartment2 ()
    { 
        SceneManager.LoadScene("Apartment2");
    }

    public void Apartment3 ()
    { 
        SceneManager.LoadScene("Apartment3");
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

    public void LoadArbitraryScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Assessment()
    {
        SceneManager.LoadScene("PretestScreen");
    }
}
