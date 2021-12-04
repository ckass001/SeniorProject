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
    }

    public void updateIcons(Sprite filename)
    {
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
        }
    }
}
