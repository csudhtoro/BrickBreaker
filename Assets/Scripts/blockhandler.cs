using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockhandler : MonoBehaviour
{

    public Transform boomObj;
    public Transform sizeUpObj;
    public Transform sizeDownObj;
    public Transform speedUpObj;
    public Transform instaKillObj;
    public Transform rocketBallObj;

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
        int whichPowerUp = Random.Range(0, 5);



        Instantiate(boomObj, transform.position, boomObj.rotation);
        Destroy(gameObject);

        if (whichPowerUp == 0) {
            Debug.Log(whichPowerUp + " : sizeUp");
            Instantiate(sizeUpObj, transform.position, sizeUpObj.rotation);
        }
        else if (whichPowerUp == 1)
        {
            Debug.Log(whichPowerUp + " : speedUp");
            Instantiate(speedUpObj, transform.position, speedUpObj.rotation);
        }
        else if(whichPowerUp == 2)
        {
            Debug.Log(whichPowerUp + " : sizeDown");
            Instantiate(sizeDownObj, transform.position, sizeDownObj.rotation);
        }
        else if (whichPowerUp == 3)
        {
            Debug.Log(whichPowerUp + " : instaKill");
            Instantiate(instaKillObj, transform.position, instaKillObj.rotation);
        }
        else if (whichPowerUp == 4)
        {
            Debug.Log(whichPowerUp + " : instaKill");
            Instantiate(rocketBallObj, transform.position, rocketBallObj.rotation);
        }



    }
}
