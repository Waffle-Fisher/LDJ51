using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    private float _timer = 0f;
    private GameObject _detector;
    private float _totalRotationTime = 10f;
    private float _rotationPerSecond;

    void Start()
    {
        _detector = GetComponentInChildren<BoxCollider>().gameObject;
        _rotationPerSecond = 360f / _totalRotationTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (HasTenSecsPassed())
        {
            Debug.Log("Ten secs has passed");
        }

        _detector.transform.RotateAround(transform.position, transform.up, _rotationPerSecond * Time.deltaTime);
    }

    private bool HasTenSecsPassed()
    {
        if(_timer <= 10f) { return false; }
        _timer = 0f;
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have hit something!");
    }
}
