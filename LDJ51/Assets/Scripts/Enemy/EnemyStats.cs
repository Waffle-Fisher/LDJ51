using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private EnemySO Stats;
    public float MaxHealth { get; private set; }
    public float MoveSpeed { get; private set; }
    public float VanishSpeed { get; private set; }
    public float LightIntensity { get; private set; }


    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        MaxHealth = Stats.MaxHealth;
        MoveSpeed = Stats.MoveSpeed;
        transform.localScale = Stats.Scale;
        LightIntensity = Stats.LightIntensity;
        VanishSpeed = Stats.VanishSpeed;
    }
}
