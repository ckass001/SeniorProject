using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleGraphQL;
public class DecissionButtonFill : MonoBehaviour
{
    public Text[] dcButtonText;
    public Text dcText;
    public Text[] chButtonText;
    Response<Data> dcResponse;
    Response<Data2> chResponse;

    [System.Serializable]
    public class Node
    {
        public float id { get; set; }
        public string title { get; set; }
        public string statement { get; set; }
    }
    [System.Serializable]
    public class Edge
    {
        public Node node { get; set; }
    }
    [System.Serializable]
    public class AllDecisionsfiltered
    {
        public List<Edge> edges { get; set; }
    }
    [System.Serializable]
    public class Data
    {
        public AllDecisionsfiltered allDecisionsfiltered { get; set; }
    }
    [System.Serializable]
    public class Node2
    {
        public float id { get; set; }
        public string statement { get; set; }
        public float bankInfluence { get; set; }
        public float moraleInfluence { get; set; }
    }
    [System.Serializable]
    public class Edge2
    {
        public Node2 node { get; set; }
    }
    [System.Serializable]
    public class AllChoicesfiltered
    {
        public List<Edge2> edges { get; set; }
    }
    [System.Serializable]
    public class Data2
    {
        public AllChoicesfiltered allChoicesfiltered { get; set; }
    }

    private void Start()
    {
        fillDcButtons();
    }
    public async void fillDcButtons()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"query allDc
                    {
                        allDecisionsfiltered(lesson_Id: 1)
                        {
                        edges
                        {
                            node
                            {
                            id
                            title
                            statement
                            }
                        }
                        }
                    }"
        };
        Data listOfLessons = new Data();
        dcResponse = await client.Send(() => listOfLessons, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        //Debug.Log(response.Data.allDecisionsfiltered.edges[1].node.statement);
        for(int i = 0; i < 4; i++)
        {
            try
            {
                dcButtonText[i].text = dcResponse.Data.allDecisionsfiltered.edges[i].node.title;
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
            Query = @"query allChF($decision_Lesson_Id: Float!)
                    {
                      allChoicesfiltered(decision_Lesson_Id: $decision_Lesson_Id)
                      {
                        edges
                        {
                          node
                          {
                            id
                            statement
                            bankInfluence
                            moraleInfluence
                          }
                        }
                      }
                    }",
            Variables = new
            {
                decision_Lesson_Id = dcResponse.Data.allDecisionsfiltered.edges[(int)decission].node.id
            }
        };
        Data2 listOfLessons = new Data2();
        chResponse = await client.Send(() => listOfLessons, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        dcText.text = dcResponse.Data.allDecisionsfiltered.edges[decission].node.statement;
        for (int i = 0; i < 4; i++)
        {
            try
            {
                chButtonText[i].text += chResponse.Data.allChoicesfiltered.edges[i].node.statement;
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
}
