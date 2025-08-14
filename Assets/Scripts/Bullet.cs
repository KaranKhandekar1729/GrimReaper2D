using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // private float destroyDelay = 1.0f;
    // public GameObject bullet;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

        if (other.CompareTag("player"))
        {
            return;
        }
    }

}
