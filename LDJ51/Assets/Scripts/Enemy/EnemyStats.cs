using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private EnemySO Stats;
    public float MaxHealth { get; private set; }
    public float MoveSpeed { get; private set; }
    public int Damage { get; private set; }

    public float VanishSpeed { get; private set; }
    public float LightIntensity { get; private set; }

    public Color ModelColor { get; private set; }
    public Color LightColor { get; private set; }

    private void Awake()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        MaxHealth = Stats.MaxHealth;
        MoveSpeed = Stats.MoveSpeed;
        Damage = Stats.Damage;

        transform.localScale = Stats.Scale;
        VanishSpeed = Stats.VanishSpeed;
        LightIntensity = Stats.LightIntensity;
        ModelColor = Stats.ModelColor;
        LightColor = Stats.LightColor;
    }
}
