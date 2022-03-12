using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFront : MonoBehaviour
{

    public PlayerController Controller;
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
            print("Obstacle on Front");
            Controller.CanMoveFront = false;
        }
       // else
       // {
       //     Controller.CanMoveFront = true;

       // }


    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WhatStopsMovement")
        {
            Controller.CanMoveFront = true;
        }
    }*/
}