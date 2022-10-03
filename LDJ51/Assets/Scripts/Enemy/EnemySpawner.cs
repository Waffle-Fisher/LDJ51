using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int _numEnemies = 100;
    [SerializeField] private float _minSpawnDist = 10f;
    [SerializeField] private float _maxSpawnDist = 100f;
    [SerializeField] private float _spawnTimer = 10f;
    public float MinSpawnDist { get { return _minSpawnDist; } }
    public float MaxSpawnDist { get { return _maxSpawnDist; } }
    

    private List<GameObject> Enemies = new();

    private void Awake()
    {
        if(Instance == null) { Instance = this; }
        else { Destroy(Instance); }
        PopulateEnemies();
    }
    private void PopulateEnemies()
    {
        for (int i = 0; i < _numEnemies; i++)
        {
            CreateEnemies();
        }
    }

    private void CreateEnemies()
    {
        GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity, transform);
        enemy.SetActive(false);
        Enemies.Add(enemy);
    }

    private void Start()
    {
        StartCoroutine(SummonEnemies());
    }

    private IEnumerator SummonEnemies()
    {
        while (true)
        {
            int i = UnityEngine.Random.Range(1, 10);
            EnableObjectsInPool(i);
            Debug.Log("Num enemies spawned: " + i);
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    private void EnableObjectsInPool(int amount)
    {
        int i = 0;
        while(amount > 0 || i >= Enemies.Count)
        {
            if (Enemies[i].activeInHierarchy == false)
            {
                Enemies[i].SetActive(true);
                amount--;
            }
            i++;
        }
        if (i >= Enemies.Count)
        {
            Debug.Log("Not Enough enemies available to spawn");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _minSpawnDist);
        Gizmos.DrawWireSphere(transform.position, _maxSpawnDist);
    }
}
