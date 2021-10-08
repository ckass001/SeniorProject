using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestionController : MonoBehaviour
{
    public Text QuestionField;
    public Text AnswerChoiceA;
    public Text AnswerChoiceB;
    public Text AnswerChoiceC;
    public Text AnswerChoiceD;
    
    public class Question
    {
        public string MainQuestion;
        public string ChoiceA;
        public string ChoiceB;
        public string ChoiceC;
        public string ChoiceD;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void readFromJSON()
    { 
        
    }

}
