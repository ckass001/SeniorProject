using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
public class inputQueary : MonoBehaviour
{
    [System.Serializable]
    public class AllAuthor
    {
        public string firstName;
        public string lastName;
    }
    [System.Serializable]
    public class Data
    {
        public List<AllAuthor> allAuthors;
    }
    [System.Serializable]
    public class Root
    {
        public Data data;
    }

    public string firstName;
    public string lastName;
    public string FName;
    public string LName;
    public Text textField;
    public GraphQLConfig Config;
    public void Start()
    {
        if (!File.Exists(@".\Assets\Files\test.graphql"))
        {
            File.Create(@".\Assets\Files\test.graphql");
        }
    }

    public async void testQuery()
    {
        var graphQL = new GraphQLClient(Config);
        Query query = graphQL.FindQuery("sampleQuearyFile");

        string results = await graphQL.Send(
        query.ToRequest(new Dictionary<string, object>
        {
            {"variable", "value"}
        }),
        null,
       "authToken",
       "Bearer"
        );
        File.WriteAllText(@".\Assets\Files\test.json",results);
        Root listOfStudents = new Root();
        listOfStudents = JsonUtility.FromJson<Root>(results);
        for(int i = 0; i < listOfStudents.data.allAuthors.Count;i++)
        {
            textField.text += (listOfStudents.data.allAuthors[i].firstName + " " + listOfStudents.data.allAuthors[i].lastName);
        }
    }
    public async void testMutation()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
var request = new Request
{
    Query = @"mutation AddAuthor($first: String!, $last: String!) {
        createAuthor(
        authorData: {
            firstName: $first,
            lastName:  $last
        }
        ) {
        author {
            firstName
        }
        }
    }",
    Variables = new
    {
        first = FName,
        last = LName
    }
};
var responseType = new { createAuthor = new { author = new { firstName = "" } } };
var response = await client.Send(() => responseType, request);
//Debug.Log(response.Result.Data.createAuthor.author.firstName);
        
    }
    public void readFName(string input)
    {
        FName = input;
    }
    public void readLName(string input)
    {
        LName = input;
    }
}