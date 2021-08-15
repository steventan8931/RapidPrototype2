using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatPadScr : MonoBehaviour
{
    public int m_WaterCount = 0;
    public AudioSource m_Audio;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 4)
        {
            //change cube to heat cubeX  destroy heat cube
            collision.gameObject.GetComponent<WaterFunc>().changeForm(3);
            m_WaterCount++;
            if (!m_Audio.isPlaying)
            {
                m_Audio.Play();
            }
        }
    }
}
