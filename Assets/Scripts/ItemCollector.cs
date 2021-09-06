using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int orangeCounter = 0;
    [SerializeField] private Text orangeCounterText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            orangeCounter++;
            orangeCounterText.text = "Oranges: " + orangeCounter;
        }
    }
}
