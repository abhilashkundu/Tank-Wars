using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifPowerAquired : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Tank1" || collision.gameObject.tag == "Tank2")
        {
            Destroy(gameObject);
        }
    }
}
