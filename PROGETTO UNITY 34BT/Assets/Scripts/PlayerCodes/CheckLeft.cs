using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLeft : MonoBehaviour
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
            print("Obstacle on Left");
            Controller.CanMoveLeft = false;
        }
        else
        {
            Controller.CanMoveLeft = true;

        }


    }


    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WhatStopsMovement")
        {
            Controller.CanMoveLeft = true;
        }
    }*/
}