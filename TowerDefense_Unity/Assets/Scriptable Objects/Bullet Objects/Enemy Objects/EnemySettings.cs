using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EnemySettings", fileName = "new EnemySettings")]
public class EnemySettings : ScriptableObject
{
    [Header("Enemy Settings")]
    public float startHealth = 0f;
    public float moveSpeed = 0f;
    public int killReward = 0;
}