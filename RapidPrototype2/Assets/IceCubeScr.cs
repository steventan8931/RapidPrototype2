using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeScr : MonoBehaviour
{
    public int m_WaterCount = 0;
    public bool isAppearing = true;
    public GameObject IceLayer1, IceLayer2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 4 && isAppearing )
        {
            //change cube to heat cubeX  destroy heat cube
            collision.gameObject.GetComponent<WaterFunc>().changeForm(2);
            collision.gameObject.GetComponent<WaterFunc>().Invoke("destroyWater", 0.5f);
            m_WaterCount++;

        }
    }

    private void FixedUpdate()
    {
        if(m_WaterCount >= 10)
        {
            IceLayer2.SetActive(true);
        }

    
    }
}
