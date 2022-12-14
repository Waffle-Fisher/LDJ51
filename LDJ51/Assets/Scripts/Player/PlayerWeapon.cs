using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _weaponDmg = 1f;
    public float WeaponDmg { get { return _weaponDmg; } }
    private AudioSource _audioSource;
    private Transform _parent;
    private ParticleSystem _ps;
    private ParticleSystem.EmissionModule _em;
    private bool _canFire = false;
    private List<ParticleSystem.Particle> enter = new();
    private ParticleSystem.ColliderData hitObj;

    private void Start()
    {
        _parent = GetComponentInParent<PlayerControls>().transform;
        _ps = GetComponentInChildren<ParticleSystem>();
        _em = _ps.emission;
        _em.enabled = _canFire;
        _ps.Play();
        _audioSource = GetComponent<AudioSource>();
    }

    public void RotateWeapon(float r)
    {
        transform.RotateAround(_parent.position, Vector3.up, r);
    }

    // 2 Ways to shoot
    // Press space to enable shooting, press again to disable
    //public void ToggleShooting()
    //{
    //    _canFire = !_canFire;
    //    _em.enabled = _canFire;
        
    //}

    // Hold down space to shoot
    public void Fire(bool b)
    {
        _em.enabled = b;
        if (b && !_audioSource.isPlaying)
        {
            StartCoroutine(PlayFireSFX());
        }
    }

    private IEnumerator PlayFireSFX()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(0.7f);
        _audioSource.Stop();
    }
}
