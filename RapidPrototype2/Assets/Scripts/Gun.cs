using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject m_Model;

    public Transform m_FirePoint;

    public GameObject m_ProjectilePrefab;

    public float m_ShotDelayTimer = 0.0f;
    public float m_ShotDelay = 0.01f;

    public AudioSource m_Audio;

    public int m_TotalWater = 0;
    public int m_CurrentWater = 0;

    private void Start()
    {
        m_CurrentWater = m_TotalWater;
    }
    private void Update()
    {
        float CameraOffset = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraOffset);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mouseWorldPosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (m_Model.transform.localScale.x > 0)
        {
            transform.localRotation = Quaternion.Euler(-angle, 0, 0);
        }
        else if (m_Model.transform.localScale.x < 0)
        {
            transform.localRotation = Quaternion.Euler(angle - 180, 0, 0);
        }

        if (m_ShotDelayTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0) && m_CurrentWater > 0)
            {
                Instantiate(m_ProjectilePrefab, m_FirePoint.position, transform.rotation);
                m_CurrentWater--;
                m_ShotDelayTimer = m_ShotDelay;
                if (!m_Audio.isPlaying)
                {
                    m_Audio.Play();
                }
            }
            else
            {
                m_Audio.Stop();
            }
        }
        else
        {
            m_ShotDelayTimer -= Time.deltaTime;
        }

    }
}
