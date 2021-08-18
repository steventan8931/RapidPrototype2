using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    public float m_ProjectileSpeed = 10.0f;
    public float m_LifeTime = 0.0f;
    public float m_MaxLifeTime = 5.0f;

    public LayerMask m_HitLayerMask;
    public float m_Radius = 0.1f;
    private void Update()
    {
        if (m_LifeTime < m_MaxLifeTime)
        {
            transform.Translate(transform.forward * m_ProjectileSpeed * Time.deltaTime, transform.parent);
            m_LifeTime += Time.deltaTime;

            RaycastHit hit;
            Vector3 step = transform.forward * m_ProjectileSpeed * Time.fixedDeltaTime;
            if (Physics.SphereCast(transform.position, m_Radius, step.normalized, out hit, step.magnitude, m_HitLayerMask))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
