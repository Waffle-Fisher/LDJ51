using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Transform _parent;
    private ParticleSystem _particleShot;

    private void Start()
    {
        _parent = GetComponentInParent<PlayerControls>().transform;
        _particleShot = GetComponent<ParticleSystem>();
    }

    public void RotateWeapon(float r)
    {
        transform.RotateAround(_parent.position, Vector3.up, r);
    }

    public void Shoot()
    {
        if (_particleShot.isPlaying)
        {
            _particleShot.Play();
        }
        
    }
}
