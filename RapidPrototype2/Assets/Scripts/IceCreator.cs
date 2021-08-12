using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreator : MonoBehaviour
{
    public int m_WaterCount = 0;

    public GameObject m_IceCubePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 4 && collision.gameObject.GetComponent<WaterProjectile>() != null)
        {
            //change cube to heat cubeX  destroy heat cube
            collision.gameObject.GetComponent<WaterFunc>().changeForm(3);
            m_WaterCount++;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (m_WaterCount >= 10)
        {
            Instantiate(m_IceCubePrefab, transform.position, Quaternion.identity);
            m_WaterCount = 0;
        }
    }
}
