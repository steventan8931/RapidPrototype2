using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreator : MonoBehaviour
{
    public int m_WaterCount = 0;
    public int m_WaterNeededTomakeIce = 10;
    public GameObject m_IceCubePrefab;

    public Vector2 m_SpawnOffsetExtents = new Vector2(-1.0f, 1.0f);
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
        if (m_WaterCount >= m_WaterNeededTomakeIce)
        {
            Vector3 SpawnPos = new Vector3(transform.position.x + Random.Range(m_SpawnOffsetExtents.x, m_SpawnOffsetExtents.y), transform.position.y, transform.position.z + Random.Range(m_SpawnOffsetExtents.x, m_SpawnOffsetExtents.y));
            Instantiate(m_IceCubePrefab, SpawnPos, Quaternion.identity);
            m_WaterCount = 0;
        }
    }
}
