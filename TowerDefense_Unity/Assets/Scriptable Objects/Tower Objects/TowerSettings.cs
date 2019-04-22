using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TowerSettings", fileName = "new TowerSettings")]
public class TowerSettings : ScriptableObject
{
    [Header("Tower Settings")]
    public int buyPrice = 0;
    public float towerReachRange = 0f;
    public float fireRate = 0f;
}