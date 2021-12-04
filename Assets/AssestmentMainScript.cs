using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleGraphQL;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AssestmentMainScript : MonoBehaviour
{

    public class AllAssessment
    {
        public int id { get; set; }
        public string title { get; set; }
    }
    public class AssessmentData
    {
        public List<AllAssessment> allAssessments { get; set; }
    }

    public class AllQuestionsByAssessment
    {
        public string description { get; set; }
        public int weight { get; set; }
        public int answer { get; set; }
        public List<string> options { get; set; }
    }
    public class QuestionData
    {
        public List<AllQuestionsByAssessment> allQuestionsByAssessment { get; set; }
    }

    public class ParseAnswer
    {
        public bool ok { get; set; }
    }
    public class AnswerData
    {
        public ParseAnswer ParseAnswer { get; set; }
    }

    public class GradeAssessment
    {
        public double score { get; set; }
    }
    public class GradeData
    {
        public GradeAssessment gradeAssessment { get; set; }
    }

    Response<AssessmentData> assResponse;
    Response<QuestionData> questResponse;
    Response<AnswerData> ansResponse;
    Response<GradeData> gradeResponse;

    public Text[] QandABoxes;
    public int questionCounter;

    void Start()
    {
        questionCounter = 0;
        StartCoroutine(doStuff(questionCounter));
    }

    public async void getAssessment()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"query allAss
                        {
                          allAssessments
                          {
                            id
                            title
                          }
                        }"
        };
        AssessmentData AssData = new AssessmentData();
        assResponse = await client.Send(() => AssData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
    }

    public async void getQuestions()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"query getQuestions($assessment: ID!)
                    {
                      allQuestionsByAssessment(assessment: $assessment)
                      {
                        description
                        weight
                        answer
                        options
                      }
                    }",
            Variables = new
            {
                assessment = assResponse.Data.allAssessments[0].id
            }
        };
        QuestionData questData = new QuestionData();
        questResponse = await client.Send(() => questData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
    }

    public void fillQuestion(int questionNumber)
    {
        QandABoxes[0].text = questResponse.Data.allQuestionsByAssessment[questionNumber].description;
        for(int i=0; i< questResponse.Data.allQuestionsByAssessment[questionNumber].options.Count;i++)
        {
            if (questResponse.Data.allQuestionsByAssessment[questionNumber].options[i] != null)
                QandABoxes[(i+1)].text = questResponse.Data.allQuestionsByAssessment[questionNumber].options[i];
            else
                QandABoxes[(i+1)].text = "";
        }
    }

    public void doTheThing(int choice)
    {
        if (assResponse.Data.allAssessments.Count >= questionCounter)
        {
            StartCoroutine(doStuff(questionCounter));
            sendAnswerToBackend(choice);
        }
        else
        {
            sendAnswerToBackend(choice);
            wait(.25f);
            gradeAssessment();
            wait(.25f);
            SceneManager.LoadScene("Apartment1");
        }
    }

    IEnumerator doStuff(int question)
    { 
        getAssessment();
        yield return new WaitForSeconds(.25f);
        getQuestions();
        yield return new WaitForSeconds(.25f);
        fillQuestion(question);
        questionCounter++;
    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    public async void sendAnswerToBackend(int choice)
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"mutation gibAnswer($assessmentQuestion: ID!, $response: Int!)
                    {
                      ParseAnswer(assessmentQuestion: $assessmentQuestion, response: $response)
                      {
                        ok
                      }
                    }",
            Variables = new
            {
                assessmentQuestion = questionCounter,
                response = choice
            }
        };
        AnswerData ansData = new AnswerData();
        ansResponse = await client.Send(() => ansData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
    }

    public async void gradeAssessment()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"mutation gradeAss($assessment: ID!)
                    {
                      gradeAssessment(assessment: $assessment)
                      {
                        score
                      }
                    }",
            Variables = new
            {
                assessment = assResponse.Data.allAssessments[0].id
            }
        };
        GradeData gradeData = new GradeData();
        gradeResponse = await client.Send(() => gradeData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        Debug.Log(gradeResponse.Data.gradeAssessment.score);
    }
}
