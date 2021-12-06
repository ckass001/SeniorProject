using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIcons : MonoBehaviour
{
    [SerializeField] public SpriteRenderer[] spawnPoints;
    [SerializeField] public Sprite[] icons;
    private int counter;

    private void Start()
    {
        Debug.Log(SyncStats.remainingEvents[0].coffeeevent.image);
        chooseIcon(SyncStats.remainingEvents[0].coffeeevent.image);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            chooseIcon("FR");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            chooseIcon("clear");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            chooseIcon("WR");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            chooseIcon("VR");
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
