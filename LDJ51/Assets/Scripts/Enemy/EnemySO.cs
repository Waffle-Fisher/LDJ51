using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public float MaxHealth;
    public float MoveSpeed;
    public float LightIntensity;
    public int Damage;

    public Vector3 Scale;

    [Range(0f, 10f)]public float VanishSpeed;
}
