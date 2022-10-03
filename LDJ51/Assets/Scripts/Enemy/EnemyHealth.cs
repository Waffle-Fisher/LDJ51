using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyStats Stats;
    private float _currentHealth;
    private float _dmgTaken = 0f;

    private void Start()
    {
        Stats = GetComponent<EnemyStats>();
        _currentHealth = Stats.MaxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        _dmgTaken = other.gameObject.GetComponentInParent<PlayerWeapon>().WeaponDmg;
        ProcessHealth();
    }

    private void ProcessHealth()
    {
        _currentHealth -= _dmgTaken;
        GetComponent<EnemyBehavior>().RevealSelf();
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
            // Death sfx & vfx
        }
    }
}
