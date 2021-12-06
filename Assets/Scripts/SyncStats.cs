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
    public class seDetails
    {
        public List<EventsLeft> eventsLeft { get; set; }
    }
    public class StudentEvent
    {
        public bool ok { get; set; }
        public object error { get; set; }
        public seDetails details { get; set; }
    }
    public class StudentEventData
    {
        public StudentEvent studentEvent { get; set; }
    }
    public class DecisionsLeft
    {
        public string id { get; set; }
        public string title { get; set; }
        public string statement { get; set; }
    }
    public class StatEventsLeft
    {
        public string id { get; set; }
        public string title { get; set; }
        public string statement { get; set; }
        public double occurrenceProbability { get; set; }
    }
    public class GetStats
    {
        public int morale { get; set; }
        public int coffeeValue { get; set; }
        public int bank { get; set; }
        public List<DecisionsLeft> decisionsLeft { get; set; }
        public List<StatEventsLeft> eventsLeft { get; set; }
    }
    public class StatData
    {
        public GetStats getStats { get; set; }
    }

    public static Response<SwitchLessonData> slResponse;
    public static Response<StudentEventData> seResponse;
    public static Response<StatData> stResponse;

    public static List<EventsLeft> remainingEvents;

    private void Start()
    {
        syncAllStats();
    }

    public static async void switchLesson(int ls)
    {
        var client = new GraphQLClient(SaveBetweenScenes.URL);
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
                              image
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

    public static async void switchLessonStartOver(int ls)
    {
        var client = new GraphQLClient(SaveBetweenScenes.URL);
        var request = new Request
        {
            Query = @"mutation switchLesson($lesson: ID!, $module: ID!, startOver: true)
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
                              image
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

    public static async void studentEvent()
    {
        var client = new GraphQLClient(SaveBetweenScenes.URL);
        var request = new Request
        {
            Query = @"mutation studentEvent($eventp: ID!,$module: ID!)
                    {
                      studentEvent(event:$eventp, module:$module)
                      {
                        ok
                        error
                        details
                        {
                          eventsLeft
                          {
                            coffeeevent
                            {
                              id
                              title
                              statement
                              image
                              bankInfluence
                              moraleInfluence
                            }
                          }
                        }
                      }
                    }",
            Variables = new
            {
                eventp = remainingEvents[0].coffeeevent.id,
                module = 1
            }
        };
        StudentEventData seData = new StudentEventData();
        seResponse = await client.Send(() => seData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        if (seResponse.Data.studentEvent.details.eventsLeft != null)
            remainingEvents = seResponse.Data.studentEvent.details.eventsLeft;
        else
            remainingEvents = null;
    }

    public static async void syncAllStats()
    {
        var client = new GraphQLClient(SaveBetweenScenes.URL);
        var request = new Request
        {
            Query = @"query getStats
                    {
                      getStats
                      {
                        morale
                        coffeeValue
                        bank
                        decisionsLeft
                        {
                          id
                          title
                          statement
                        }
                        eventsLeft
                        {
                          id
                          title
                          statement
                          occurrenceProbability
                        }
                      }
                    }"
        };
        StatData stData = new StatData();
        stResponse = await client.Send(() => stData, request, null, SaveBetweenScenes.authenticationToken, "Bearer");
        SaveBetweenScenes.playerBank = stResponse.Data.getStats.bank;
        SaveBetweenScenes.playerMorale = stResponse.Data.getStats.morale;
        SaveBetweenScenes.coffeeValue = stResponse.Data.getStats.coffeeValue;
        Debug.Log(stResponse.Data.getStats.bank + " " + stResponse.Data.getStats.morale + " " + stResponse.Data.getStats.coffeeValue);
    }
}
