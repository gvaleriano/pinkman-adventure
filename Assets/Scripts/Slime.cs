using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Collect slime to inventory and destroy object
            //collision.GetComponent<Player>().numberSlime++;
            collision.GetComponent<Player>().CollectObjects("Slime");
            Destroy(gameObject);
        }
    }
}
