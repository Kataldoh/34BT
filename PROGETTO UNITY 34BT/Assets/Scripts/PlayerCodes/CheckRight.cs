using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRight : MonoBehaviour
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
            print("Obstacle on Right");
            Controller.CanMoveRight = false;
        }
        else
        {
            Controller.CanMoveRight = true;

        }

    }
}