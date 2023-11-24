using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Collect kiwi to inventory and destroy object
            //collision.GetComponent<Player>().numberKiwi++;
            collision.GetComponent<Player>().CollectObjects("Kiwi");
            Destroy(gameObject);
        }
    }
}
