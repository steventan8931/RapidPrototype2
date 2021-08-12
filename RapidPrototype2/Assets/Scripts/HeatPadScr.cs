using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatPadScr : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 4)
        {
            //change cube to heat cube
            collision.gameObject.GetComponent<WaterFunc>().changeForm(3);

        }
    }
}
