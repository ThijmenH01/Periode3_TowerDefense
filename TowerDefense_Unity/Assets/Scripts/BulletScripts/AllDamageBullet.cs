using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDamageBullet : Bullet {
    protected override void HitTarget(Enemy enemy) {
        ExplosionDamage(enemy.transform.position, bulletSettings.bulletExplosionRange);
    }

    void ExplosionDamage(Vector3 center, float radius) {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        for (int i = 0; i < hitColliders.Length; i++) {
            Enemy enemy = hitColliders[i].GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(bulletSettings.bulletDamage);
            }
        }
    }
}
