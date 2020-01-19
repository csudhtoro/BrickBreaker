using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockhandler : MonoBehaviour
{
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
        int randomNum = Random.Range(0, 7);
        if (randomNum == 5) Debug.Log("Powerup produced!");

        Destroy(gameObject);
    }
}
