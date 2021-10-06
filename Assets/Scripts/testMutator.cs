using SimpleGraphQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMutator : MonoBehaviour
{
    public GraphQLConfig Config;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        testMutation();
    }

    public async void testMutation()
    {
        var graphQL = new GraphQLClient(Config);

        // You can search by file name, operation name, or operation type
        // or... mix and match between all three
        Query query = graphQL.FindQuery("sampleMutatorFile");

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
