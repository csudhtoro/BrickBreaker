using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketHandler : MonoBehaviour
{
    public float xBound = 3.0f;
    public string axis = "Horizontal";
    public float paddleSpeed = 150;

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * paddleSpeed;

        float p = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(p, 0) * paddleSpeed;
        var pos = transform.position;
        if (pos.x > xBound) pos.x = xBound;
        else if (pos.x < -xBound) pos.x = -xBound;
    }

    /*void paddleBound()
    {
        float h = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0) * paddleSpeed;

        var pos = transform.position;
        if (pos.x > xBound) pos.x = xBound;
        else if (pos.x < -xBound) pos.x = -xBound;
    }*/
}
