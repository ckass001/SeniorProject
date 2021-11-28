using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DelayModule : MonoBehaviour
{
    void Start()
    {
        DOVirtual.DelayedCall(3, GotoNextScene);

    
    }

    void GotoNextScene ()
    {
        SceneManager.LoadScene("Classroom");
    }

}
