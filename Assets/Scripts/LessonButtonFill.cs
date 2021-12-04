using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonButtonFill : MonoBehaviour
{
    [System.Serializable]
    public class Module
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int startingBank { get; set; }
        public int startingMorale { get; set; }
    }
    [System.Serializable]
    public class AllLesson
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public Module module { get; set; }
    }
    [System.Serializable]
    public class Data2
    {
        public List<AllLesson> allLessons { get; set; }
    }

    public Text buttonTextField1;
    public Text buttonTextField2;
    public Text buttonTextField3;
    public Text buttonTextField4;
    public Text buttonTextField5;

    private async void Start()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"query allLessons
                    {
                      allLessons
                      {
                        id,
                        title,
                        description,
                        content,
                        module
                        {
                          id,
                          title,
                          description,
                          startingBank,
                          startingMorale
                        }
                      }
                    }"
        };
        Data2 listOfLessons = new Data2();
        var response = await client.Send(() => listOfLessons, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        buttonTextField1.text = response.Data.allLessons[0].title + System.Environment.NewLine + response.Data.allLessons[0].description;
        buttonTextField2.text = response.Data.allLessons[1].title + System.Environment.NewLine + response.Data.allLessons[1].description;
        buttonTextField3.text = response.Data.allLessons[2].title + System.Environment.NewLine + response.Data.allLessons[2].description;
        buttonTextField4.text = response.Data.allLessons[3].title + System.Environment.NewLine + response.Data.allLessons[3].description;
        buttonTextField5.text = response.Data.allLessons[4].title + System.Environment.NewLine + response.Data.allLessons[4].description;
    }
}
