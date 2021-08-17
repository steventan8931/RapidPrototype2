using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillCrystal : MonoBehaviour
{
    public float m_RotationTimer = 0.0f;
    public float m_RotationSpeed = 20.0f;

    public float m_BobSpeed = 5.0f;
    public float m_YOrigin = 3.95f;

    public Transform m_Pivot;

    public bool m_Collected = false;

    public AudioSource m_Audio;

    public float m_AudioTimer;
    public float m_DestoryTime = 0.5f;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.GetComponent<CharacterMotor>() != null)
        {
            m_Audio.Play();
            _other.GetComponent<CharacterMotor>().m_WaterCrystalCollected = true;
            m_Collected = true;
        }
    }

    private void Update()
    {
        if(m_Collected)
        {
            m_AudioTimer += Time.deltaTime;
            if (m_AudioTimer > m_DestoryTime)
            {
                m_Audio.Stop();
                Destroy(gameObject);
            }
        }
        if (m_RotationTimer < 360)
        {
            m_RotationTimer += Time.deltaTime * m_RotationSpeed;
        }
        else
        {
            m_RotationTimer = 0;
        }
        m_Pivot.transform.rotation = Quaternion.Euler(0.0f, m_RotationTimer, 0.0f);

        float YPos = Mathf.Sin(Time.time * m_BobSpeed) + m_YOrigin;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
    }
}
