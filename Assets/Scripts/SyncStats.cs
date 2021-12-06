using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleGraphQL;
public class SyncStats : MonoBehaviour
{
    public class Coffeeevent
    {
        public string id { get; set; }
        public string title { get; set; }
        public string statement { get; set; }
        public string image { get; set; }
        public int bankInfluence { get; set; }
        public double moraleInfluence { get; set; }
    }
    public class EventsLeft
    {
        public Coffeeevent coffeeevent { get; set; }
    }
    public class Details
    {
        public int coffeeValue { get; set; }
        public int morale { get; set; }
        public int bank { get; set; }
        public List<EventsLeft> eventsLeft { get; set; }
    }
    public class SwitchLesson
    {
        public Details details { get; set; }
    }
    public class SwitchLessonData
    {
        public SwitchLesson switchLesson { get; set; }
    }

    public static Response<SwitchLessonData> slResponse;
    public static List<EventsLeft> remainingEvents;
    public static async void switchLesson(int ls)
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"mutation switchLesson($lesson: ID!, $module: ID!)
                    {
                      switchLesson(lesson: $lesson,module: $module)
                      {
                        details
                        {
                          coffeeValue
                          morale
                          bank
                          eventsLeft
                          {
                            coffeeevent
                            {
                              id
                              title
                              statement
                              bankInfluence
                              moraleInfluence
                            }
                          }
                        }
                      }
                    }",
            Variables = new
            {
                module = 1,
                lesson = ls
            }
        };
        SwitchLessonData questData = new SwitchLessonData();
        slResponse = await client.Send(() => questData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        remainingEvents = slResponse.Data.switchLesson.details.eventsLeft;
    }

    public static async void syncAllStats()
    {

    }
}
