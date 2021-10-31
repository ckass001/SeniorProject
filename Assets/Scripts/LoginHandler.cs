using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class LoginHandler : MonoBehaviour
{
    [System.Serializable]
    public class Payload
    {
        public string username { get; set; }
        public int exp { get; set; }
        public int origIat { get; set; }
    }
    [System.Serializable]
    public class TokenAuth
    {
        public string token { get; set; }
        public Payload payload { get; set; }
        public int refreshExpiresIn { get; set; }
    }
    [System.Serializable]
    public class Data
    {
        public TokenAuth tokenAuth { get; set; }
    }
    [System.Serializable]
    public class Root
    {
        public Data data { get; set; }
    }
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
    [System.Serializable]
    public class Root2
    {
        public Data2 data2 { get; set; }
    }

    private string userusername;
    private string userpassword;
    private string userToken;
    [SerializeField] public GraphQLConfig Config;
    public Text textField;

    public async void generateToken()
    {
    

        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"mutation TokenAuth($username: String!, $password: String!) {
                      tokenAuth(username: $username, password: $password) {
                        token
                        payload
                        refreshExpiresIn
                      }
                    }",
            Variables = new
            {
                username = userusername,
                password = userpassword
            }
        };
        //var responseType = new { createAuthor = new { author = new { firstName = "" } } };
        Data hopeThisWorks = new Data();
        var response = await client.Send(() => hopeThisWorks, request);
        userToken = response.Data.tokenAuth.token;
        addTokenHeader();
        //Debug.Log("Got This Far");
    }

    public async void quereyLessons()
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

        // You're going to need to set this to the right data type
        Data2 listOfLessons = new Data2();
        var response = await client.Send(() => listOfLessons, request, null, userToken, "Bearer");
        //var response  = await client.Send(request,null,userToken,"Bearer");
        //File.WriteAllText("Output.txt", response.Data.allLessons[0].title);
        //Debug.Log(response.Data.allLessons[0].title);
        for (int i = 0; i < response.Data.allLessons.Count; i++)
        {
            textField.text += (response.Data.allLessons[i].title + ": " + response.Data.allLessons[i].description + System.Environment.NewLine);
        }
    }

    public async void makeLesson()
    {
        var client = new GraphQLClient("http://localhost:8000/graphql/");
        var request = new Request
        {
            Query = @"mutation createLesson($content: String!, $description: String!, $module: ID!, $title: String!){  
                         createLesson(content: $content, 
                         description: $description,
  						 module: $module,
  						 title: $title){
                            ok
                         }
                    }",
            Variables = new
            {
                content = "AHGG",
                description = "In Game Made",
                module = 3,
                title = "IHateGraphQL"
            }
        };
        var returntype = new { crealeLesson = new { ok = true } };
        var response = await client.Send(() => returntype, request);
    }

    public void addTokenHeader()
    {
        Header GQLHeader = new Header();
        GQLHeader.Key = "Authorization";
        GQLHeader.Value = "Bearer " + userToken;
        Config.CustomHeaders[0] = GQLHeader;
        //Config.CustomHeaders.Add(GQLHeader);
    }

    public void readUsername(string input)
    {
        userusername = input;
    }

    public void readPassword(string input)
    {
        userpassword = input;
    }

}
