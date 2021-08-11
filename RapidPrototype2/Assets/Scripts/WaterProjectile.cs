using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    public float m_ProjectileSpeed = 10.0f;
    public float m_LifeTime = 0.0f;
    public float m_MaxLifeTime = 5.0f;

    public float m_Radius = 0.1f;

    private void Update()
    {
        if (m_LifeTime < m_MaxLifeTime)
        {
            transform.Translate(transform.forward * m_ProjectileSpeed * Time.deltaTime,transform.parent);
            m_LifeTime += Time.deltaTime;
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    //Destory if hits an object that it isnt a water projectile
    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.GetComponent<WaterProjectile>() == null)
        {
            Destroy(gameObject);
        }
    }

}
