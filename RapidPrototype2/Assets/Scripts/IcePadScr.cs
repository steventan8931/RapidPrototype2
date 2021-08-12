using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePadScr : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 4)
        {
            //change cube to ice cube
            collision.gameObject.GetComponent<WaterFunc>().changeForm(2);

        }
    }
}
