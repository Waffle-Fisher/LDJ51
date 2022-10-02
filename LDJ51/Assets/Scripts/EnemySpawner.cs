using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int _numEnemies = 100;
    [SerializeField] private float _minSpawnDist = 10f;
    [SerializeField] private float _maxSpawnDist = 100f;
    List<GameObject> Enemies = new();

    private void Start()
    {
        PoolEnemies();
    }

    private void PoolEnemies()
    {
        for (int i = 0; i < _numEnemies; i++)
        {
            CreateEnemies();
            Enemies[i].SetActive(true);
        }
    }

    private void CreateEnemies()
    {
        Vector2 rv = Random.insideUnitCircle.normalized;
        rv *= Random.Range(_minSpawnDist, _maxSpawnDist);
        Vector3 spawnPos = new(rv.x, EnemyPrefab.transform.localScale.y / 2f, rv.y);
        GameObject enemy = Instantiate(EnemyPrefab, spawnPos, Quaternion.identity, transform);
        Enemies.Add(enemy);
    }

    private void Update()
    {
        SummonEnemies();
    }

    private void SummonEnemies()
    {

    }
}
