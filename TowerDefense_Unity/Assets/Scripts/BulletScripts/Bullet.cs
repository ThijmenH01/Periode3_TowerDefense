using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public static Bullet Instance { get; private set; }

    protected Enemy enemy;
    public BulletSettings bulletSettings;

    protected void Start()
    {
        Instance = this;
    }

    protected void Update()
    {
        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * bulletSettings.bulletVelocity);
        if (transform.position == enemy.transform.position)
        {
            HitTarget(enemy);
            Destroy(gameObject);
        }
    }

    protected virtual void HitTarget(Enemy enemy)
    {

    }

    public void SetTarget(Enemy enemy) => this.enemy = enemy;
}
