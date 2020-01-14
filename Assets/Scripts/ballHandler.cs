using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballHandler : MonoBehaviour
{

    public float ballSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "paddle")
        {
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
    }
}
