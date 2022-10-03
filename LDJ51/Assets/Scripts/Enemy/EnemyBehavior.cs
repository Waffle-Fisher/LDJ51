using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    
    private EnemyStats Stats;
    private Light _pointLight;
    private Renderer _renderer;
    private Color c;
    private bool _hasBeenHit = false;
    private Vector3 _targetPos;
    
    private bool _tookDmg = false;

    private void OnEnable()
    {
        Stats = GetComponent<EnemyStats>();
        
        Initialize();
    }
    private void Initialize()
    {
        InitializeLight();
        InitializeColor();
        SetSpawnPos();
        _tookDmg = false;
        _targetPos = new Vector3(0, transform.position.y, 0);
        transform.LookAt(_targetPos);
    }

    private void SetSpawnPos()
    {
        Vector2 rv = UnityEngine.Random.insideUnitCircle.normalized;
        rv *= UnityEngine.Random.Range(EnemySpawner.Instance.MinSpawnDist, EnemySpawner.Instance.MaxSpawnDist);
        transform.position = new(rv.x, transform.localScale.y / 2f, rv.y);
    }

    private void InitializeLight()
    {
        _pointLight = GetComponentInChildren<Light>();
        _pointLight.color = Stats.LightColor;
        _pointLight.intensity = 0f;
    }
    private void InitializeColor()
    {
        _renderer = GetComponent<Renderer>();
        //c = _renderer.material.color;
        c = Stats.ModelColor;
        c.a = 0f;
        _renderer.material.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        RevealSelf();
    }

    public void RevealSelf()
    {
        c.a = 1f;
        _renderer.material.color = c;
        _pointLight.intensity = Stats.LightIntensity;
        _hasBeenHit = true;
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            ProcessMove();
            ProcessFade();
        }
    }
    private void ProcessMove()
    {
        if ( (transform.position - _targetPos).sqrMagnitude <= 1f)
        {
            PlayerHealth.Instance.DecreaseHealth(Stats.Damage);
            gameObject.SetActive(false);
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        transform.LookAt(_targetPos);
        transform.Translate(Stats.MoveSpeed * Time.deltaTime * transform.forward,Space.World);
    }

    private void ProcessFade()
    {
        if (_hasBeenHit)
        {
            _hasBeenHit = false;
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade()
    {
        while(c.a >= 0f)
        {
            //// Color opacity
            //c.a -= Time.deltaTime / (float)Stats.VanishSpeed;
            //Debug.Log($"{gameObject.name} has: {Resources.FindObjectsOfTypeAll(typeof(Material)).Length} materials");
            //_renderer.material.color = c;
            // Light Intensity
            float dimRate = Stats.LightIntensity * Time.deltaTime / (float)Stats.VanishSpeed;
            _pointLight.intensity -= dimRate;
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(GetComponent<Mesh>());

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }
}
