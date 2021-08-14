using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float m_Length;
    public float m_StartPos;

    public GameObject m_Camera;

    public float m_ParallaxEffect;

    private void Start()
    {
        m_StartPos = transform.position.x;
        m_Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float tempPos = m_Camera.transform.position.x * (1 - m_ParallaxEffect);
        float distance = m_Camera.transform.position.x * m_ParallaxEffect;
        transform.position = new Vector3(m_StartPos + distance, transform.position.y, transform.position.z);

        if (tempPos > m_StartPos + m_Length)
        {
            m_StartPos += m_Length;
        }
        else if (tempPos < m_StartPos - m_Length)
        {
            m_StartPos -= m_Length;
        }
    }
}
