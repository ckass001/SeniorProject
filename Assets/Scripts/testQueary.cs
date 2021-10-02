using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testQueary : MonoBehaviour
{
    public GraphQLConfig Config;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        testQuery();
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

        Debug.Log(results);
    }
}
