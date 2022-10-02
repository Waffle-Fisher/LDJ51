using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemySO _stats;
    private GameObject _pointLight;
    private Renderer _renderer;
    private Color c;
    private bool _hasBeenHit = false;
    private Vector3 _targetPos;

    private void Awake()
    {
        InitializeLight();
        InitializeColor();
        _targetPos = new Vector3(0, transform.position.y, 0);
        transform.localScale = _stats.Scale;
        transform.LookAt(_targetPos);
    }
    private void InitializeLight()
    {
        _pointLight = GetComponentInChildren<Light>().gameObject;
        _pointLight.SetActive(false);
    }
    private void InitializeColor()
    {
        _renderer = GetComponent<Renderer>();
        c = _renderer.material.color;
        c.a = 1f;
        c.a = float.Epsilon;
        _renderer.material.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has hit me!");
        c.a = 1f;
        _renderer.material.color = c;
        _hasBeenHit = true;
    }

    private void Update()
    {
        ProcessMove();
        ProcessFade();
    }
    private void ProcessMove()
    {
        if ( (transform.position - _targetPos).sqrMagnitude <= _stats.AttackRange * _stats.AttackRange)
        {
            Debug.Log("I have reached the target!");
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
       transform.Translate(_stats.MoveSpeed * Time.deltaTime * transform.forward,Space.World);
    }

    private void ProcessFade()
    {
        if (c.a <= 0f)
        {
            _hasBeenHit = false;
        }
        if (_hasBeenHit)
        {
            Fade();
        }
    }
    void Fade()
    {
        c.a -= (Time.deltaTime / (float)_stats.VanishSpeed);
        _renderer.material.color = c;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(GetComponent<Mesh>());

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }
}
