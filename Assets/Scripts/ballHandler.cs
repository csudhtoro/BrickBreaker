using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballHandler : MonoBehaviour
{
    public Transform boomObj;
    TrailRenderer ballTrail;
    public float ballSpeed = 20.0f;
    Rigidbody2D thisBallMass;
    Collider2D thisBallCollision;

    // Start is called before the first frame update
    void Start()
    {
        thisBallMass = gameObject.GetComponent<Rigidbody2D>();
        thisBallCollision = gameObject.GetComponent<Collider2D>();
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
        ballTrail = gameObject.GetComponent<TrailRenderer>();
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

        if (collision.gameObject.name == "deathBounds")
        {
            Instantiate(boomObj, transform.position, boomObj.rotation);
            Destroy(gameObject);
        }
        
    }

    void increaseSpeed()
    {
        ballSpeed = ballSpeed * 1.2f;
        ballTrail.emitting = true;
    }

    void decreaseSpeed() { ballSpeed = ballSpeed / 2f; }
    void indestructable() { thisBallCollision.isTrigger = true; }
    void normalizeBall() { thisBallCollision.isTrigger = false; }
    void normalizeBallSpeed(){ballSpeed = 7; }


    //NOT WORKING PROPERLY. BALLS STILL HIT EACH OTHER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "metalBall")
        {
            Physics2D.IgnoreCollision(collision, thisBallCollision);
        }
    }
}
