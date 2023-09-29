using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankDestroyScript : MonoBehaviour
{
    private int lifeOfTank1 = 3;
    public GameObject Tank;
    //public bool Win = false;
    [SerializeField] ButtonAndSceneControllerAndTankChecker checker;
    private void OnAwake()
    {
        Tank = GameObject.FindGameObjectWithTag("Tank1").GetComponent<GameObject>();
        //Win = false;
        lifeOfTank1 = 3;
    }

    private void Update()
    {
        if(lifeOfTank1 == 0)
        {
            //Win = true;
            lifeOfTank1 = 3;
            checker.BroadcastMessage("win", 2);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "mortar1")
        {
            lifeOfTank1 -= 1;
        }
    }
}
