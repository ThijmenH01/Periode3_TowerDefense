using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }

    public EnemySettings enemySettings;
    private int currentWaypoint;
    public float health;
    private float speed;

    [SerializeField] private float startTimer = 10;
    [SerializeField] private float endTimer = 0;

    public bool slowedDown = false; 

    public enum moveStatus { Normal, Slow }
    public moveStatus m_moveStatus;

    private void Start()
    {
        m_moveStatus = moveStatus.Normal;
        Instance = this;
        health = enemySettings.startHealth;
        speed = enemySettings.moveSpeed;
        Vector2Int nextWaypoint = GameManager.Instance.enemyPath[currentWaypoint];
        GameObject targetTile = GameManager.Instance.grid[nextWaypoint.y, nextWaypoint.x];
        transform.position = targetTile.transform.position;
        GameManager.Instance.RegisterEnemy(this);
    }

    private void Update()
    {
        if (GameManager.Instance.enemyPath.Length - 1 == currentWaypoint)
        {
            GameManager.Instance.DamagePlayer(1);
            Destroy(gameObject);
            return;
        }

        Vector2Int nextWaypoint = GameManager.Instance.enemyPath[currentWaypoint + 1];
        GameObject targetTile = GameManager.Instance.grid[nextWaypoint.y, nextWaypoint.x];
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetTile.transform.position) == 0f)
        {
            currentWaypoint++;
        }
        GetsKilled();
        MovementBehavior();
    }

    private void GetsKilled()
    {
        if (enemySettings.startHealth <= 0)
        {
            Balance.Instance.balance += enemySettings.killReward;
            Destroy(gameObject);
        }
    }

    private void MovementBehavior()
    {
        if(m_moveStatus == moveStatus.Normal)
        {
            speed = enemySettings.moveSpeed;
        }

        if (m_moveStatus == moveStatus.Slow)
        {
            speed = 0.25f;

            if (startTimer <= endTimer)
            {
                //Debug.Log("test");
                m_moveStatus = moveStatus.Normal;
                slowedDown = false;
                startTimer = 10;
            }
            else
            {
                startTimer -= Time.deltaTime;
            }
        }
    }

    private void OnDestroy() => GameManager.Instance.HandleEnemyDeath(this);

    public void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, int.MaxValue);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
