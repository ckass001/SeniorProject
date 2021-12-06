using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleGraphQL;
using UnityEngine.UI;
public class QuearyLesson : MonoBehaviour
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

    public Text contentTextField;
    public async void  quearyLessonContentByNumber(int lessonNumber)
    {
        var client = new GraphQLClient(SaveBetweenScenes.URL);
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
        contentTextField.text = response.Data.allLessons[lessonNumber].content;
    }
}
