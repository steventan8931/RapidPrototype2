
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterFunc : MonoBehaviour
{
    public int CubeState = 1;
    public Material WaterM, IceM, HeatM;  
    public GameObject waterSelf;
    public void destroyWater()
    {

        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
       if(CubeState == 3)
        {

            //Invoke("destroyWater()", 0.5f);
            //destroyWater();
        }    

    }
    public void changeForm(int formnum)
    {
        CubeState = formnum;
        if (formnum == 2)
        {
          waterSelf.GetComponent<Renderer>().material = IceM;
        }

        if (formnum == 3)
        {
            waterSelf.GetComponent<Renderer>().material = HeatM;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 4) // Water layer
        {
            if (collision.gameObject.GetComponent<WaterFunc>().CubeState == 2) //Ice form
            {
                changeForm(2);
            }
            else if (collision.gameObject.GetComponent<WaterFunc>().CubeState == 3) //Heat form
            {
                changeForm(3);
            }
            else
            {

            }
        }
    }

}
