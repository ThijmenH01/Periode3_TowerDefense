using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject gridTilePrefab;
    public GameObject gridPathPrefab;
    public GameObject enemyPrefab;  
    public GameObject selectorPrefab;

    [Header("Grid Coordinates")]
    public GameObject[] enemyPrefabs;
    public GameObject[,] grid;
    public GameObject[,] buildings; 
    public GameObject[] buildingPrefabs;
    public Vector2Int[] enemyPath;

    [Header("Values")]
    public int playerHealth;
    private float spawnInterval = 1f;
    private float spawnDelay = 5f;
    public int minUnitsPerWave;
    public int maxUnitsPerWave;
    public int unitAddon = 1;
    public int currentWave = 1;

    [Header("Lists")]
    public List<Enemy> enemies = new List<Enemy>();
    private List<Tower> towers = new List<Tower>();
    //private List<SlowDownTower> slowDownTowers = new List<SlowDownTower>();
    public int tower1Price;
    public int enemyHealthIncrement;

    private int size = 12;

    public static GameManager Instance { get; private set; }

    private void Awake() => Startup();

    private void Update()
    {
        PlayerDies();

        if (currentWave % 5 == 0)
        {
            unitAddon++;
        }
    }

    private void Startup()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;

        spawnDelay = 5f;

        grid = new GameObject[size, size];
        buildings = new GameObject[size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject prefab = null;
                if (Array.IndexOf(enemyPath, new Vector2Int(x, y)) == -1)
                {
                    prefab = gridTilePrefab;
                }
                else
                {
                    prefab = gridPathPrefab;
                }
                grid[y, x] = Instantiate(prefab, new Vector3(x, y), Quaternion.identity);
            }
        }
        Instantiate(selectorPrefab);
        StartCoroutine(SpawnWavesAsync());
    }

    public void RegisterTower(Tower tower) => towers.Add(tower);
    //public void RegisterTowerSlowDown(SlowDownTower slowDownTower) => slowDownTowers.Add(slowDownTower);
    public void RegisterEnemy(Enemy enemy) => enemies.Add(enemy);
    public void HandleEnemyDeath(Enemy enemy) => enemies.Remove(enemy);
    public void DamagePlayer(int damage) => playerHealth = Mathf.Clamp(playerHealth - damage, 0, int.MaxValue); 

    private IEnumerator SpawnWavesAsync()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnUnitAsync());
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private IEnumerator SpawnUnitAsync()
    {
        int unitCounter = 0;
        int numUnits = UnityEngine.Random.Range(minUnitsPerWave, maxUnitsPerWave);
        int randomEnemies = UnityEngine.Random.Range(0, enemyPrefabs.Length);

        Debug.Log("New Wave Started");

        currentWave++;

        minUnitsPerWave += unitAddon;
        maxUnitsPerWave += unitAddon;

        print("WaveCount: " + currentWave);

        while (unitCounter <= numUnits)
        {
            Instantiate(enemyPrefabs[randomEnemies]);
            unitCounter++;

            if (unitCounter < numUnits)
            {
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private void PlayerDies()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 10;
            //Restart();
            print("Loaded Scene");
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
        Startup();
    }
}
