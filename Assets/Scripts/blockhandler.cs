using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockhandler : MonoBehaviour
{

    public Transform boomObj;
    public Transform sizeUpObj;
    public Transform sizeDownObj;
    public Transform speedUpObj;
    public Transform slowDownObj;
    public Transform instaKillObj;
    public Transform rocketBallObj;
    public Transform multiBallObj;
    public Transform indestructableObj;
    public Transform slowBallObj;
    bool triggerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Random random = new Random();
        int whichPowerUp = Random.Range(5, 7);
        //int whichPowerUp = 6;


        Instantiate(boomObj, transform.position, boomObj.rotation);
        Destroy(gameObject);

        if (whichPowerUp == 0) {
            //Debug.Log(whichPowerUp + " : sizeUp");
            Instantiate(sizeUpObj, transform.position, sizeUpObj.rotation);
        }
        else if (whichPowerUp == 1)
        {
            //Debug.Log(whichPowerUp + " : speedUp");
            Instantiate(speedUpObj, transform.position, speedUpObj.rotation);
        }
        else if(whichPowerUp == 2)
        {
            //Debug.Log(whichPowerUp + " : sizeDown");
            Instantiate(sizeDownObj, transform.position, sizeDownObj.rotation);
        }
        else if (whichPowerUp == 3)
        {
            //Debug.Log(whichPowerUp + " : instaKill");
            Instantiate(instaKillObj, transform.position, instaKillObj.rotation);
        }
        else if (whichPowerUp == 4)
        {
            //Debug.Log(whichPowerUp + " : rocketball");
            Instantiate(rocketBallObj, transform.position, rocketBallObj.rotation);
        }
        else if (whichPowerUp == 5)
        {
            //Debug.Log(whichPowerUp + " : multiBallObj");
            Instantiate(multiBallObj, transform.position, multiBallObj.rotation);
        }
        else if (whichPowerUp == 6)
        {
            Instantiate(slowBallObj, transform.position, slowBallObj.rotation);

        }
        else if (whichPowerUp == 7)
        {
            Instantiate(slowDownObj, transform.position, slowDownObj.rotation);
        }
        
        else if (whichPowerUp == 8)
        {
            Instantiate(indestructableObj, transform.position, indestructableObj.rotation);
            triggerOn = true;
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
