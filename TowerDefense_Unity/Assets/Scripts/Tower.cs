using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Bullet bullet;
    public TowerSettings towerSettings;
    public GameObject bulletPrefab;
    //public GameObject slowBulletPrefab;
    private float cooldownTimer;

    void Start() => GameManager.Instance.RegisterTower(this);

    void Update()
    {
        List<Enemy> enemies = GameManager.Instance.enemies;
        if (cooldownTimer == 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (Vector3.Distance(transform.position, enemies[i].transform.position) < towerSettings.towerReachRange)
                {
                    bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
                    bullet.SetTarget(enemies[i]);
                    cooldownTimer = towerSettings.fireRate;
                    break;
                }

                //if (Vector3.Distance(transform.position, enemies[i].transform.position) < towerSettings.towerReachRange && enemies[i].slowedDown == false)
                //{
                //    SlowBullet slowBullet = Instantiate(slowBulletPrefab, transform.position, Quaternion.identity).GetComponent<SlowBullet>();
                //    slowBullet.SetTarget(enemies[i]);
                //    cooldownTimer = towerSettings.fireRate;
                //    break;
                //}
            }
        }

        else
        {
            cooldownTimer = Mathf.Clamp(cooldownTimer - Time.deltaTime, 0f, float.MaxValue);
        }
    }
}
