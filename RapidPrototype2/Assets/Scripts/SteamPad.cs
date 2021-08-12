using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPad : MonoBehaviour
{
    public int m_WaterCount = 0;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Water")
        {
            m_WaterCount++;
        }
    }
}
