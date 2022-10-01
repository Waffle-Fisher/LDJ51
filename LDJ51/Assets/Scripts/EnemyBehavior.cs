using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject _pointLight;

    private void Start()
    {
        _pointLight = GetComponentInChildren<Light>().gameObject;
        _pointLight.SetActive(false);
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has hit me!");
        _pointLight.SetActive(true);
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
