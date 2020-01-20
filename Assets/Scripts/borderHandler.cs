using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderHandler : MonoBehaviour
{

    Collider2D ballCollision;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "metalBall")
        {
            Debug.Log(collision.gameObject.name);
            ballCollision = collision.gameObject.GetComponent<Collider2D>();
            ballCollision.isTrigger = false;
        }

    }
}
