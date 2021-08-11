﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterFunc : MonoBehaviour
{
    public int CubeState = 1;
    public Material WaterM, IceM, HeatM;
    public GameObject waterSelf;
    private void FixedUpdate()
    {
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 4) // Water layer
        {
            if (collision.gameObject.GetComponent<WaterFunc>().CubeState == 2) //Ice form
            {
                CubeState = 2;
                waterSelf.GetComponent<Renderer>().material = IceM;
            }
            else if (collision.gameObject.GetComponent<WaterFunc>().CubeState == 3) //Heat form
            {
                CubeState = 3;
                waterSelf.GetComponent<Renderer>().material = HeatM;
            }
            else
            {

            }
        }
    }

}
