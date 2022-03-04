using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBack : MonoBehaviour
{

    public PlayerController Controller;
   

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "WhatStopsMovement")
        {
            print("Obstacle on back");
            Controller.CanMoveBack = false;
        }
        else
        {
            Controller.CanMoveBack = true;

        }

    }
}
