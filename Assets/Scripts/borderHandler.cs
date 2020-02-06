using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderHandler : MonoBehaviour
{

    Collider2D ballCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "metalBall")
        {
            ballCollision = collision.gameObject.GetComponent<Collider2D>();
        }

    }
}
