using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroyScript1 : MonoBehaviour
{
    private int lifeOfTank2 = 3;
    public GameObject Tank2;
    //public bool Win1 = false;
    [SerializeField] ButtonAndSceneControllerAndTankChecker checkerr;
    private void OnAwake()
    {
        Tank2 = GameObject.FindGameObjectWithTag("Tank2").GetComponent<GameObject>();
        //Win1 = false;
        lifeOfTank2 = 3;
    }
    private void Update()
    {
        if (lifeOfTank2 == 0)
        {
            //Win1 = true;
            lifeOfTank2 = 3;
            checkerr.BroadcastMessage("win", 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mortar")
        {
            lifeOfTank2 -= 1;
        }
    }
}
