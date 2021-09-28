using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBalance : MonoBehaviour
{
    public int PlayerBalance;
    [SerializeField] private Text BalancUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Worth"))
        {
            PlayerBalance += collision.gameObject.GetComponent<ItemBalance>().worth;
            BalancUI.text = "Balace: $" + PlayerBalance;
        }
    }
}
