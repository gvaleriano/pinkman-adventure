using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    public BoxCollider2D boxCollider;
    public TargetJoint2D targetJoint;

    void Falling()
    {
        boxCollider.enabled = false;
        targetJoint.enabled = false;
        Destroy(gameObject, fallingTime + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Invoke("Falling", fallingTime);   
        }
    }
}
