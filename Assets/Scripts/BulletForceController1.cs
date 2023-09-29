using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForceController1 : MonoBehaviour
{
    [SerializeField]tankmovement2 tank2;
    private void Start()
    {
        tank2 = GameObject.FindGameObjectWithTag("Tank2").GetComponent<tankmovement2>();
        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tank1") || collision.gameObject.CompareTag("Tank2"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "shield" && tank2.shieldOn == false)
        {
            Destroy(this.gameObject);
        }
    }
}
