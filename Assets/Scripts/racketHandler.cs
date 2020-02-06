using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketHandler : MonoBehaviour
{

    GameObject ball, deathBound;
    GameObject[] balls;
    GameObject[] borders;
    Collider2D ballCollision;

    public string axis = "Horizontal";
    public float paddleSpeed = 150;
    

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
        
        borders = GameObject.FindGameObjectsWithTag("border");
        deathBound = GameObject.FindGameObjectWithTag("deathArea");
        Debug.Log(gameObject.layer);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * paddleSpeed;

        float p = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(p, 0) * paddleSpeed;
        balls = GameObject.FindGameObjectsWithTag("ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ball == null) balls = GameObject.FindGameObjectsWithTag("ball");
        

        if (collision.gameObject.name == "shrinkPaddleBlockObj(Clone)") shrinkPaddle();
        else if (collision.gameObject.name == "enlargePaddleBlockObj(Clone)") enlargePaddle();
        else if (collision.gameObject.name == "slowPaddleDownBlockObj(Clone)") slowPaddleDown();
        else if (collision.gameObject.name == "speedPaddleUpBlockObj(Clone)") speedPaddleUp();
        else if (collision.gameObject.name == "slowBallDownBlockObj(Clone)") slowBallsDown();
        else if (collision.gameObject.name == "speedBallUpBlockObj(Clone)") speedBallsUp();
        else if (collision.gameObject.name == "indestructibleBlockObj(Clone)") indestructibleBall();

        else if (collision.gameObject.name == "multiBallBlockObj(Clone)")
        {
            foreach (GameObject ballObj in balls)
            {
                Instantiate(ballObj);
            }
            balls = GameObject.FindGameObjectsWithTag("ball");
        }

        else if (collision.gameObject.name == "instaKillBlockObj(Clone)")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.name == "instaKillBlockObj(Clone)")
        {
            Destroy(gameObject);
        }
    }


    //Functions modifying the Paddle
    void shrinkPaddle()
    {
        if (GetComponent<Transform>().localScale.x >= 0.47f)
        {
            GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x / 2, .488f);
        }
        Invoke("normalizePaddleSize", 7);
    }

    void enlargePaddle()
    {
        if (GetComponent<Transform>().localScale.x <= 0.47f)
        {
            GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x * 2, .488f);
        }
        Invoke("normalizePaddleSize", 7);
    }

    void normalizePaddleSize() { GetComponent<Transform>().localScale = new Vector2(0.47f, 0.488f); }
  

    void speedPaddleUp()
    {
        if (paddleSpeed <= 13)
        {
            paddleSpeed = paddleSpeed * 2.0f;
        }
        Invoke("normalizePaddleSpeed", 7);
    }

    void slowPaddleDown()
    {
        if (paddleSpeed >= 13)
        {
            paddleSpeed = paddleSpeed / 2.0f;
        }
        Invoke("normalizePaddleSpeed", 7);
    }

    void normalizePaddleSpeed() { paddleSpeed = 13; }


    //Functions modifying the ball
    void slowBallsDown()
    {
        foreach (GameObject ballObj in balls)
        {
            ballObj.SendMessage("decreaseSpeed", 0.5f, SendMessageOptions.RequireReceiver);
        }
        Invoke("normalizeBallSpeeds", 5);
    }

    void speedBallsUp()
    {
        foreach (GameObject ballObj in balls)
        {
            ballObj.SendMessage("increaseSpeed", 0.5f, SendMessageOptions.RequireReceiver);
        }
        Invoke("normalizeBallSpeeds", 5);
    }

    void normalizeBallSpeeds()
    {
        foreach (GameObject ballObj in balls)
        {
            ballObj.SendMessage("normalizeBallSpeed", 0.5f, SendMessageOptions.RequireReceiver);
            ballObj.GetComponent<TrailRenderer>().emitting = false;
        }
    }

    void indestructibleBall()
    {
        gameObject.layer = 8;
        Debug.Log(gameObject.layer);
        foreach (GameObject ballObj in balls)
        {
            ballObj.layer = 8;
        }
        foreach (GameObject border in borders)
        {
            border.layer = 8;
        }
        deathBound.layer = 8;
        Invoke("normalizeBall", 5);
    }

    void normalizeBall()
    {
        gameObject.layer = 0;
        Debug.Log("ball trigger turning off!");
        foreach (GameObject ballObj in balls)
        {
            ballObj.layer = 0;
        }
        foreach (GameObject border in borders)
        {
            border.layer = 0;
        }
        deathBound.layer = 0;
    }
}

