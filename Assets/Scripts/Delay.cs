using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Delay : MonoBehaviour
{
    void Start()
    {
        DOVirtual.DelayedCall(3, GotoNextScene);
    }

    // Update is called once per frame
    void GotoNextScene ()
    {
        SceneManager.LoadScene("Lesson UI");
    }
}
