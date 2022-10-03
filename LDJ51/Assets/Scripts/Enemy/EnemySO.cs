using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    // Stats
    public float MaxHealth;
    public float MoveSpeed;
    public int Damage;

    // Visuals
    public Vector3 Scale;
    [Range(0f, 10f)]public float VanishSpeed;
    public float LightIntensity;
    public Color ModelColor;
    public Color LightColor;
}
