using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "BulletSettings", fileName = "new BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("Bullet Settings")]
    public float bulletVelocity = 0f;
    public int bulletDamage = 0;
    public float enemyMoveSpeedSlowDown = 0f;
    public float bulletExplosionRange = 0f;
}