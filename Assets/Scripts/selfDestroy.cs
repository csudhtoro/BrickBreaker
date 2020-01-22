using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "paddle" || collision.gameObject.name == "deathBounds")
        {
            Destroy(gameObject);
        }
    }
}
