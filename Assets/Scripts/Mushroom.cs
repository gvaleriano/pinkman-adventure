using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Collect melon to inventory and destroy object
            //collision.GetComponent<Player>().numberMushroom++;
            collision.GetComponent<Player>().CollectObjects("Mushroom");
            Destroy(gameObject);
        }
    }
}
