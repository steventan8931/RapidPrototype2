using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 m_StartPosition;
    public Vector3 m_EndPosition;

    public bool m_IsOpen = false;
    public float m_DoorOpenTimer = 0.0f;
    public float m_DoorOpenSpeed = 0.5f;

    bool m_CacheBool;

    public AudioSource m_Audio;

    private void Start()
    {
        m_CacheBool = m_IsOpen;
        m_Audio.enabled = false;
    }

    private void Update()
    {
        if (m_CacheBool != m_IsOpen)
        {
            //If changed
            m_Audio.enabled = true;
            m_DoorOpenTimer = 0.0f;
            m_CacheBool = m_IsOpen;
        }
        if (m_IsOpen)
        {
            if (transform.position != m_EndPosition)
            {
                m_DoorOpenTimer += Time.deltaTime * m_DoorOpenSpeed;
                if (m_Audio.enabled)
                {
                    if (!m_Audio.isPlaying)
                    {
                        m_Audio.Play();
                    }
                }
            }

            transform.position = Vector3.Lerp(transform.position, m_EndPosition, m_DoorOpenTimer);
 
        }
        else
        {
            if (transform.position != m_StartPosition)
            {
                m_DoorOpenTimer += Time.deltaTime * m_DoorOpenSpeed;
            }
            transform.position = Vector3.Lerp(transform.position, m_StartPosition, m_DoorOpenTimer);
        }
    }
}
