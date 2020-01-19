using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketHandler : MonoBehaviour
{
    
    public string axis = "Horizontal";
    public float paddleSpeed = 150;


    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * paddleSpeed;

        float p = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(p, 0) * paddleSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "sizeDown(Clone)")
        {
            if (GetComponent<Transform>().localScale.x >= 0.47f) {

                GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x / 2, .488f);
            }
        }

        else if (collision.gameObject.name == "sizeUp(Clone)")
        {
            if (GetComponent<Transform>().localScale.x <= 0.47f) {

                GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x * 2, .488f);
            }
        }

        else if (collision.gameObject.name == "speedUp(Clone)")
        {
            if (paddleSpeed < 20)
            {
                paddleSpeed = paddleSpeed * 2.0f;
            }
        }
        else if (collision.gameObject.name == "rocketBall(Clone)")
        {

        }
        else if (collision.gameObject.name == "instaKill(Clone)")
        {
            Destroy(gameObject);
        }
    }

}
