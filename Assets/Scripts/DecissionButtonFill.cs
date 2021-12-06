using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleGraphQL;
using System;

public class DecissionButtonFill : MonoBehaviour
{
    public Text[] dcButtonText;
    public Text evButtonText;
    public Text evButtonText2;
    public Text dcText;
    public Text[] chButtonText;
    Response<DecisionData> dcResponse;
    Response<ChoiceData> chResponse;

    public class AllDecision
    {
        public string id { get; set; }
        public string title { get; set; }
        public string statement { get; set; }
    }

    public class DecisionData
    {
        public List<AllDecision> allDecisions { get; set; }
    }
    public class AllChoice
    {
        public string statement { get; set; }
        public int bankInfluence { get; set; }
        public double moraleInfluence { get; set; }
    }

    public class ChoiceData
    {
        public List<AllChoice> allChoices { get; set; }
    }

    private void Start()
    {
        fillDcButtons();
        fillEvButton();
    }
    public async void fillDcButtons()
    {
        Debug.Log(SaveBetweenScenes.currentLesson);
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"query allDecisions($lesson: ID!)
                    {
                      allDecisions(lesson: $lesson)
                      {
                        id
                        title
                        statement
                      }
                    }",
            Variables = new
            {
                lesson = SaveBetweenScenes.currentLesson
            }
        };
        DecisionData dcData = new DecisionData();
        dcResponse = await client.Send(() => dcData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        //Debug.Log(response.Data.allDecisionsfiltered.edges[1].node.statement);
        for(int i = 0; i < 4; i++)
        {
            try
            {
                dcButtonText[i].text = dcResponse.Data.allDecisions[i].title;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    public async void fillChButtons(int decission)
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"query allChoices($decision: ID!)
                    {
                        allChoices(decision: $decision)
                        {
                        statement
                        bankInfluence
                        moraleInfluence
                        }
                    }",
            Variables = new
            {
                decision = dcResponse.Data.allDecisions[(int)decission].id
            }
        };
        ChoiceData chData = new ChoiceData();
        chResponse = await client.Send(() => chData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        dcText.text = dcResponse.Data.allDecisions[decission].statement;
        for (int i = 0; i < 4; i++)
        {
            try
            {
                chButtonText[i].text += chResponse.Data.allChoices[i].statement;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    public void clearChButtons()
    {
        chButtonText[0].text = "A)";
        chButtonText[1].text = "B)";
        chButtonText[2].text = "C)";
        chButtonText[3].text = "D)";
    }

    public void fillEvButton()
    {
        evButtonText.text = SyncStats.remainingEvents[0].coffeeevent.title;
        evButtonText2.text = SyncStats.remainingEvents[0].coffeeevent.statement + Environment.NewLine + "Effect on your Bank Account: " + SyncStats.remainingEvents[0].coffeeevent.bankInfluence + Environment.NewLine + "Effect on Moral: " + SyncStats.remainingEvents[0].coffeeevent.moraleInfluence;
    }
}
