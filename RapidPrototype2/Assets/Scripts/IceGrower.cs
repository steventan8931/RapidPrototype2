using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGrower : MonoBehaviour
{
    public float m_DecayTimer = 0.0f;
    public float m_DecayRate = 0.5f;
    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.GetComponent<WaterProjectile>() != null)
        {
            Destroy(_collision.gameObject);
            if (transform.localScale.x < 2.0f)
            {
                transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            }
        }
    }

    private void Update()
    {
        //Decay Ice over size
        m_DecayTimer += Time.deltaTime;
        if (m_DecayTimer > m_DecayRate)
        {
            if (transform.localScale.x > 0.5f)
            {
                transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                m_DecayTimer = 0;
            }
        }

    }
}
