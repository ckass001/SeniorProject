using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIcons : MonoBehaviour
{
    [SerializeField] public static SpriteRenderer[] spawnPoints;
    [SerializeField] public static Sprite[] icons;
    private int counter;

    private void Start()
    {
        chooseIcon(SyncStats.remainingEvents[0].coffeeevent.image);
    }

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

    public static void updateIcons(Sprite filename)
    {
        for(int i = 0; i< spawnPoints.Length; i++)
        {
            spawnPoints[i].sprite = filename;
        }
    }

    public static void chooseIcon(string icon)
    {
        switch(icon)
        {
            case "clear":
                updateIcons(icons[0]);
                break;
            case "FR":
                updateIcons(icons[1]);
                break;
            case "WR":
                updateIcons(icons[2]);
                break;
            case "VR":
                updateIcons(icons[3]);
                break;
        }
    }
}
