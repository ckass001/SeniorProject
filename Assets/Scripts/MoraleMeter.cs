using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoraleMeter : MonoBehaviour
{


    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text bank;
    SpawnIcons SPI;
    private void Start()
    {
        SetMaxMorale(SaveBetweenScenes.playerMorale);
        SetMorale(SaveBetweenScenes.playerMorale);
        if (SyncStats.remainingEvents[0] == null)
        {
            SPI.chooseIcon("clear");
        }
        bank.text = "Balance: " + SaveBetweenScenes.playerBank;
    }

    public void SetMaxMorale(int morale)
    {
        slider.maxValue = morale;
        slider.value = morale;

        fill.color = gradient.Evaluate(1); 
    }

    
    public void SetMorale(int morale)
    {
        slider.value = morale;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
