using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    [SerializeField] private float _detectorLength = 10f;
    private float _previousDLength = 10f;
    private float _timer = 0f;
    private GameObject _detector;
    private float _totalRotationTime = 10f;
    private float _rotationPerSecond;


    void Start()
    {
        _detector = GetComponentInChildren<BoxCollider>().gameObject;
        _rotationPerSecond = 360f / _totalRotationTime;
        ProcessDetectorSizeChange();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessDetectorSizeChange();
        _timer += Time.deltaTime;
        if (HasTenSecsPassed())
        {
            Debug.Log("Ten secs has passed");
        }

        _detector.transform.RotateAround(transform.position, Vector3.up, _rotationPerSecond * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have hit something!");
    }

    private bool HasTenSecsPassed()
    {
        if (_timer <= 10f) { return false; }
        _timer = 0f;
        return true;
    }
    private void ProcessDetectorSizeChange()
    {
        if (_detectorLength != 0)
        {
            if (_detectorLength != _previousDLength)
            {
                ChangeDetectorSize();
            }
            _previousDLength = _detectorLength;
        }
    }

    private void ChangeDetectorSize()
    {
        _detector.transform.position *= _detectorLength / _previousDLength;
        _detector.transform.position = new Vector3(_detector.transform.position.x, 0.5f, _detector.transform.position.z);
        _detector.transform.localScale = new Vector3(_detector.transform.localScale.x, _detector.transform.localScale.y, _detectorLength);
    }
}
