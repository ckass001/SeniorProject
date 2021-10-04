using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class inputQueary : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public GraphQLConfig Config;
    public void Start()
    {
        if (!File.Exists(@".\Files\test.graphql"))
        {
            File.Create(@".\Files\test.graphql");
        }
    }

    public async void testQuery()
    {
        var graphQL = new GraphQLClient(Config);

        // You can search by file name, operation name, or operation type
        // or... mix and match between all three
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
        File.WriteAllText(@".\Files\test.graphql", results);
        if(File.Exists(@".\Files\test.json"))
        File.Delete(@".\Files\test.json");
        File.Move(@".\Files\test.graphql", @".\Files\test.json");
        Debug.Log(JsonUtility.FromJson<string>(@".\Files\test.json"));
        Debug.Log(results);
    }

}
