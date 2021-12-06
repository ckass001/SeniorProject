using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonButtonFill : MonoBehaviour
{
    public class AllLesson
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }
    public class LessonData
    {
        public List<AllLesson> allLessons { get; set; }
    }

    Response<LessonData> lsResponse;

    public Text[] buttonTextField;

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
            Query = @"query allLessons($course: ID!, $module: ID!)
                    {
                      allLessons(course:$course, module:$module)
                      {
                        id
                        title
                        description
                        content
                      }
                    }",
            Variables = new
            {
                course = 1,
                module = 1
            }
        };
        LessonData lsData = new LessonData();
        lsResponse = await client.Send(() => lsData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        for(int i = 0; i < SaveBetweenScenes.currentLesson;i++)
        {
            buttonTextField[i].text = lsResponse.Data.allLessons[i].title + System.Environment.NewLine + lsResponse.Data.allLessons[i].description;
        }
        /*buttonTextField1.text = lsResponse.Data.allLessons[0].title + System.Environment.NewLine + lsResponse.Data.allLessons[0].description;
        buttonTextField2.text = lsResponse.Data.allLessons[1].title + System.Environment.NewLine + lsResponse.Data.allLessons[1].description;
        buttonTextField3.text = lsResponse.Data.allLessons[2].title + System.Environment.NewLine + lsResponse.Data.allLessons[2].description;
        buttonTextField4.text = lsResponse.Data.allLessons[3].title + System.Environment.NewLine + lsResponse.Data.allLessons[3].description;
        buttonTextField5.text = lsResponse.Data.allLessons[4].title + System.Environment.NewLine + lsResponse.Data.allLessons[4].description;*/
    }
}
