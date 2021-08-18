using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGrower : MonoBehaviour
{
    public float m_DecayTimer = 0.0f;
    public float m_DecayRate = 0.5f;

    public float m_DecaySize = 0.01f;
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
    public void Decay(float _DecayRate)
    {
        //Decay Ice over size
        m_DecayTimer += Time.deltaTime;
        if (m_DecayTimer > m_DecayRate)
        {
            if (transform.localScale.x > 0.5f)
            {
                transform.localScale -= new Vector3(_DecayRate, _DecayRate, _DecayRate);
                m_DecayTimer = 0;
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
                transform.localScale -= new Vector3(m_DecaySize, m_DecaySize, m_DecaySize);
                m_DecayTimer = 0;
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}
