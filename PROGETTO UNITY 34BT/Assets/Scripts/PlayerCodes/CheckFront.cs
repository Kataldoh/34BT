using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFront : MonoBehaviour
{

    public PlayerController Controller;
    void Start()
    {

    }

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
        else
        {

            Controller.CanMoveFront = true;

        }

    }
}