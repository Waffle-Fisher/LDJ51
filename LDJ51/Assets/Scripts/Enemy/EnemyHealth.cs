using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] AudioClip hitSFX;
    private EnemyStats Stats;
    private float _currentHealth;
    private float _dmgTaken = 0f;
    private AudioSource _audioSource;

    private void Start()
    {
        Stats = GetComponent<EnemyStats>();
        _currentHealth = Stats.MaxHealth;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _dmgTaken = other.gameObject.GetComponentInParent<PlayerWeapon>().WeaponDmg;
        ProcessHealth();
    }

    private void ProcessHealth()
    {
        _currentHealth -= _dmgTaken;
        _audioSource.Stop();
        _audioSource.volume = 0.1f;
        _audioSource.PlayOneShot(hitSFX);
        GetComponent<EnemyBehavior>().RevealSelf();
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
