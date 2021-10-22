using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Text QuestionText;
    [SerializeField] private Image QuestionBackgroundImage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        QuestionText.enabled = true;
        QuestionBackgroundImage.enabled = true;
        QuestionText.text = "Good morning. Now, Bob has been crunching some numbers and has come to the realization that there is no way he can afford this apartment on his own. ";
    }
}
