using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncorrectOption : MonoBehaviour
{
    [SerializeField] private Text QuestionText;
    [SerializeField] private Image QuestionBackgroundImage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        QuestionText.enabled = true;
        QuestionBackgroundImage.enabled = true;
        QuestionText.text = "Sorry, Try Again!";
    }
}
