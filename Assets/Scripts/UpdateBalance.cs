using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBalance : MonoBehaviour
{
    public int PlayerBalance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Worth"))
        {
            PlayerBalance += collision.gameObject.GetComponent<ItemBalance>().worth;
        }
    }
}
