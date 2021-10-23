using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectOption : MonoBehaviour
{
    [SerializeField] private Text QuestionText;
    [SerializeField] private Image QuestionBackgroundImage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        QuestionText.enabled = true;
        QuestionBackgroundImage.enabled = true;
        QuestionText.text = "Thankfully, the apartment is large enough to accommodate an additional person.Bob is going to have a roommate.";
    }
}
