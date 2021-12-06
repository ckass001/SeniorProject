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
        //clamps morale so it doesn't go below -10 and does go above 10; also allows moral to move up and down with corresponding keys
        currentMorale = Mathf.Clamp(currentMorale,-10,maxMorale);

        //prints morale value to the console 
        Debug.Log(currentMorale);

        // press "d" to deduct morale and reduce bar
         if(Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(2);
        }

        // press "a" to add morale and increase bar
        if(Input.GetKey(KeyCode.A))
        {
            AddMorale(1);
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
