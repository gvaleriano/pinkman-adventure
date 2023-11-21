using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Collect melon to inventory and destroy object
            //collision.GetComponent<Player>().numberMelons++;
            collision.GetComponent<Player>().CollectObjects("Melon");
            Destroy(gameObject);
        }
    }
}
