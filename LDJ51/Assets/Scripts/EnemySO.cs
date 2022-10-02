using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public float MaxHealth;
    public float MoveSpeed;
    public float AttackRange;
    public DisappearRate VanishSpeed;
    public enum DisappearRate { VerySlow = 10, Slow = 8, Medium = 5, Fast = 3, Quick = 1, Instant = 0 }


}
