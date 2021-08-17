using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRefill : MonoBehaviour
{
    public int m_WaterPerCharge = 1;
    public AudioSource m_Audio;

    private void OnTriggerStay(Collider _other)
    {
        if(_other.tag == "Player")
        {
            if (_other.transform.GetChild(0).GetChild(1).GetComponent<Gun>().m_CurrentWater < _other.transform.GetChild(0).GetChild(1).GetComponent<Gun>().m_TotalWater)
            {
                if (!m_Audio.isPlaying)
                {
                    m_Audio.Play();
                }
                _other.transform.GetChild(0).GetChild(1).GetComponent<Gun>().m_CurrentWater += m_WaterPerCharge;
            }
        }
    }
}
