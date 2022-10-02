using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private InputAction Rotate;
    [SerializeField] private InputAction Shoot;
    [SerializeField] private float RotationSpeed = 5f;
    private PlayerWeapon _weapon;

    private void OnEnable()
    {
        Rotate.Enable();
        Shoot.Enable();
    }

    private void OnDisable()
    {
        Rotate.Disable();
        Shoot.Disable();
    }

    private void Start()
    {
        _weapon = GetComponentInChildren<PlayerWeapon>();
    }

    private void Update()
    {
        ProcessWeaponRotation();
        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if(Shoot.IsInProgress())
        {
            Debug.Log("I'm firing!");
            _weapon.Shoot();
        }
    }

    private void ProcessWeaponRotation()
    {
        if (Rotate.IsInProgress())
        {
            float r = Rotate.ReadValue<float>() * RotationSpeed * Time.deltaTime;
            _weapon.RotateWeapon(r);
        }
    }
}

