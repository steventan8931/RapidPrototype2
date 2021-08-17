using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaterBarScr : MonoBehaviour
{
    public Image WaterBar;
    public float currentWater;
    public float maxWater = 1000f;
    public Gun playerGun;
    private void Start()
    {
        WaterBar = GetComponent<Image>();

    }
    private void Update()
    {
        currentWater = playerGun.m_CurrentWater;
        WaterBar.fillAmount = currentWater / maxWater;
    }
}
