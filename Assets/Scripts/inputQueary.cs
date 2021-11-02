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
    public string token;
    public void Start()
    {
        //if (!file.exists(@".\assets\files\test.graphql"))
        //{
        //    file.create(@".\assets\files\test.graphql");
        //}
    }

    /*public async void testingStuff()
    {
        Header GQLHeader = new Header();
        GQLHeader.Key = "Authorization";
        GQLHeader.Value = "JWT " + token;
        Config.CustomHeaders.Add(GQLHeader);
    }*/

    public async void testQuery()
    {
        var client = new GraphQLClient("http://localhost:8000/designer_api/");
        var request = new Request
        {
            Query = @"query {
            allAuthors {
            firstName,
            lastName
            }
            }"
        };

        // You're going to need to set this to the right data type
        Data listOfStudents = new Data();
        var response = await client.Send(() => listOfStudents, request);
        //listOfStudents = JsonUtility.FromJson<Root>(results);
        for(int i = 0; i < response.Data.allAuthors.Count;i++)
        {
            textField.text += (response.Data.allAuthors[i].firstName + " " + response.Data.allAuthors[i].lastName);
        }
    }
    public async void testMutation()
    {
        var client = new GraphQLClient("http://localhost:8000/designer_api/");
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