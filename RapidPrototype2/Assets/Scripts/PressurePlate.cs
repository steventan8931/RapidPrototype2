using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door m_Door;

    public Transform m_Model;

    public Vector3 m_StartPosition;
    public Vector3 m_EndPosition;

    public bool m_Pressed = false;
    public float m_PlatePressTimer = 0.0f;
    public float m_PlatePressSpeed = 0.5f;

    bool m_CacheBool;
    Collider m_Other;

    private void Start()
    {
        m_CacheBool = m_Pressed;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "Player" || (_other.GetComponent<Rigidbody>() != null && _other.GetComponent<WaterProjectile>() == null))
        {
            m_Door.m_IsOpen = true;
            m_Pressed = true;
            m_Other = _other;
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player" || (_other.GetComponent<Rigidbody>() != null && _other.GetComponent<WaterProjectile>() == null))
        {
            m_Door.m_IsOpen = false;
            m_Pressed = false;
        }
    }

    private void Update()
    {
        if (m_Pressed && !m_Other)
        {
            m_Pressed = false;
            m_Door.m_IsOpen = false;
        }

        if (m_CacheBool != m_Pressed)
        {
            m_PlatePressTimer = 0.0f;
            m_CacheBool = m_Pressed;
        }
        if (m_Pressed)
        {
            if (m_Model.localPosition != m_EndPosition)
            {
                m_PlatePressTimer += Time.deltaTime * m_PlatePressSpeed;
                m_Door.m_Audio.enabled = true;
            }
            m_Model.localPosition = Vector3.Lerp(m_Model.localPosition, m_EndPosition, m_PlatePressTimer);
        }
        else
        {
            if (m_Model.transform.localPosition != m_StartPosition)
            {
                m_PlatePressTimer += Time.deltaTime * m_PlatePressSpeed;
            }
            m_Model.localPosition = Vector3.Lerp(m_Model.localPosition, m_StartPosition, m_PlatePressTimer);
        }
    }

}
