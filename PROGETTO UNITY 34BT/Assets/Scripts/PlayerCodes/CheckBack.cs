using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBack : MonoBehaviour
{

    public PlayerController Controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "WhatStopsMovement")
        {
            print("Obstacle on Back");
            Controller.CanMoveBack = false;

        }
        

        if (other.tag == "Walkable")
        {
            Controller.CanMoveBack = true;

        }


    }



    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WhatStopsMovement")
        {
            Controller.CanMoveBack = true;
        }
    }*/
}