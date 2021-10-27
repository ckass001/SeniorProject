using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coffeeCounter = 0;
    public int balance;
    public int costOfCoffee = 5;
    [SerializeField] private Text coffeeCounterText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coffee"))
        {
            Destroy(collision.gameObject);
            coffeeCounter++;
            coffeeCounterText.text = "Coffee Counter: " + coffeeCounter + System.Environment.NewLine + "Balance: " + balance;
        }
        if(collision.gameObject.CompareTag("Buyer"))
        {
            balance += coffeeCounter * costOfCoffee;
            coffeeCounter = 0;
            coffeeCounterText.text = "Coffee Counter: " + coffeeCounter + System.Environment.NewLine + "Balance: " + balance;
        }
    }
}
