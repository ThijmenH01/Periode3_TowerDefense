using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDamageBullet : Bullet
{
    protected override void HitTarget(Enemy enemy)
    {
        enemy.TakeDamage(bulletSettings.bulletDamage);
    }
}
