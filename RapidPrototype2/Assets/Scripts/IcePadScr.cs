using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePadScr : MonoBehaviour
{
    public int watercount;
    public GameObject Icecube;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 4)
        {
            //change cube to ice cube
            collision.gameObject.GetComponent<WaterFunc>().changeForm(2);
            collision.gameObject.GetComponent<WaterFunc>().Invoke("destroyWater", 0.5f);
            watercount++;

        }
    }

    private void FixedUpdate()
    {
        if(watercount == 10)
        {
            Icecube.SetActive(true);
        }
    }
}
