using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : Bullet
{
    protected override void HitTarget(Enemy enemy)
    {
        enemy.m_moveStatus = Enemy.moveStatus.Slow;
        enemy.slowedDown = true;
    }
}
