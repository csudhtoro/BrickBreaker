using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockhandler : MonoBehaviour
{

    public Transform boomObj;
    public Transform enlargePaddleBlockObObj;
    public Transform shrinkPaddleBlockObj;
    public Transform speedPaddleUpBlockObj;
    public Transform slowPaddleDownBlockObj;
    public Transform instaKillBlockObj;
    public Transform speedBallUpBlockObj;
    public Transform multiBallBlockObj;
    public Transform indestructibleBlockObj;
    public Transform slowBallDownBlockObj;
    bool triggerOn = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Random random = new Random();
        int whichPowerUp = Random.Range(0, 30);

        Instantiate(boomObj, transform.position, boomObj.rotation);
        Destroy(gameObject);

        switch (whichPowerUp) {

            case 0:
                Instantiate(enlargePaddleBlockObObj, transform.position, enlargePaddleBlockObObj.rotation);
                break;

            case 1:
                Instantiate(speedBallUpBlockObj, transform.position, speedBallUpBlockObj.rotation);
                break;

            case 2:
                Instantiate(shrinkPaddleBlockObj, transform.position, shrinkPaddleBlockObj.rotation);
                break;

            case 3:
                Instantiate(instaKillBlockObj, transform.position, instaKillBlockObj.rotation);
                break;

            case 4:
                Instantiate(speedBallUpBlockObj, transform.position, speedBallUpBlockObj.rotation);
                break;

            case 5:
                Instantiate(multiBallBlockObj, transform.position, multiBallBlockObj.rotation);
                break;

            case 6:
                Instantiate(slowBallDownBlockObj, transform.position, slowBallDownBlockObj.rotation);
                break;

            case 7:
                Instantiate(slowPaddleDownBlockObj, transform.position, slowPaddleDownBlockObj.rotation);
                break;

            case 8:
                Instantiate(indestructibleBlockObj, transform.position, indestructibleBlockObj.rotation);
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ball")
        {
            Debug.Log("trigger is on and ball has hit the block");
            Destroy(gameObject);
        }
    }
}
