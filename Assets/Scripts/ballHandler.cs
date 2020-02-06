using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballHandler : MonoBehaviour
{
    
    TrailRenderer ballTrail;
    public float ballSpeed = 20.0f;
    public Transform boomObj;

    // Start is called before the first frame update
    void Start()
    {
        ballTrail = gameObject.GetComponent<TrailRenderer>();
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }


    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth) { return (ballPos.x - paddlePos.x) / paddleWidth; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "paddle")
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

        if (collision.gameObject.name == "metalBall")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), collision.collider);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), collision.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), collision.collider);
        }
    }

    void increaseSpeed()
    {
        ballSpeed = ballSpeed * 1.3f;
        ballTrail.emitting = true;
    }

    void decreaseSpeed() { ballSpeed = ballSpeed / 2f; }
    
    void indestructible() {
        gameObject.layer = 8;
    }
    
    void normalizeBallSpeed() { ballSpeed = 7; }
}
