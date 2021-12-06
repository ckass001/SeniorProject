using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIcons : MonoBehaviour
{
    [SerializeField] public SpriteRenderer[] spawnPoints;
    [SerializeField] public Sprite[] icons;
    private int counter;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            chooseIcon("fire");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            chooseIcon("clear");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            chooseIcon("water");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            chooseIcon("bug");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            chooseIcon("puppy");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            chooseIcon("check");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            chooseIcon("past due");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            chooseIcon("clean");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            chooseIcon("vacation");
        }
        

    }

    public void updateIcons(Sprite filename)
    {
        Debug.Log(spawnPoints.Length);
        for(int i = 0; i< spawnPoints.Length; i++)
        {
            spawnPoints[i].sprite = filename;
        }

    }

    public void chooseIcon(string icon)
    {
        switch(icon)
        {
            case "clear":
                updateIcons(icons[0]);
                break;
            case "fire":
                updateIcons(icons[1]);
                break;
            case "water":
                updateIcons(icons[2]);
                break;
            case "bug":
                updateIcons(icons[3]);
                break;
            case "puppy":
                updateIcons(icons[4]);
                break;
            case "check":
                updateIcons(icons[5]);
                break;
            case "past due":
                updateIcons(icons[6]);
                break;
            case "clean":
                updateIcons(icons[7]);
                break;
            case "vacation":
                updateIcons(icons[8]);
                break;
        }
    }
}
