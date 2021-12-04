using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{

    public int maxMorale = 10;
    public int currentMorale;

    public MoraleMeter moralemeter;

    // Start is called before the first frame update
    void Start()
    {
        currentMorale = maxMorale;
        moralemeter.SetMaxMorale(maxMorale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            AddMorale(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentMorale -= damage;
        moralemeter.SetMorale(currentMorale);
    }

    void AddMorale(int bonus)
    {
        currentMorale += bonus;
        moralemeter.SetMorale(currentMorale);
    }
}
