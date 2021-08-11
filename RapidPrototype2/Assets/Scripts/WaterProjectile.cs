using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    public float m_ProjectileSpeed = 1.0f;
    public float m_LifeTime = 0.0f;
    public float m_MaxLifeTime = 5.0f;
    private void Update()
    {
        transform.Translate(-transform.right * m_ProjectileSpeed * Time.deltaTime);

        m_LifeTime += Time.deltaTime;

        if (m_LifeTime > m_MaxLifeTime)
        {
            Destroy(gameObject);
        }
    }

}
