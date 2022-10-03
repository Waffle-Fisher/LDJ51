using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // In the future I want _maxHealth to be changeable, not hard set to 10
    //[SerializeField][Range(3,10)] private int _maxHealth = 10;
    [SerializeField] AudioClip explosionSFX;
    private AudioSource _source;
    public static PlayerHealth Instance;
    private int _maxHealth = 10;
    private int _currentHP = 10;

    private void Start()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(Instance); }
        _currentHP = _maxHealth;
        _source = GetComponent<AudioSource>();
    }

    public void DecreaseHealth(int dmg)
    {
        _currentHP -= dmg;
        _source.Stop();
        _source.PlayOneShot(explosionSFX);
        DisplayPlayerHealth.Instance.RemoveHealthBar();
        if (_currentHP <= 0)
        {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GetComponent<PlayerControls>().enabled = false;
        CanvasController.Instance.EnableCanvas(1);
    }
}
