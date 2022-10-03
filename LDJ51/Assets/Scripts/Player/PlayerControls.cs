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

    private void ProcessWeaponRotation()
    {
        if (Rotate.IsInProgress())
        {
            float r = Rotate.ReadValue<float>() * RotationSpeed * Time.deltaTime;
            _weapon.RotateWeapon(r);
        }
    }

    // 2 Ways to shoot
    // Way 1: Press space to enable shooting, press again to disable
    //private void ProcessShooting()
    //{
    //    if(Shoot.triggered)
    //    {
    //        _weapon.ToggleShooting();
    //    }
    //}

    // Way 2: Hold down space to shoot
    private void ProcessShooting()
    {
        _weapon.Fire(Shoot.IsInProgress());
    }

    
}

