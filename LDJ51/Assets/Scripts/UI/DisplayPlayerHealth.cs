using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerHealth : MonoBehaviour
{
    public static DisplayPlayerHealth Instance;
    List<Image> _healthBars = new();
    private int _numHB = 10;
    private void Awake()
    {
        if(Instance == null) { Instance = this; }
        else { Destroy(Instance); }
        GetComponentsInChildren<Image>(_healthBars);
        RestoreBarFull();
    }

    private void RestoreBarFull()
    {
        foreach (var h in _healthBars)
        {
            h.enabled = true;
        }
    }

    public void RemoveHealthBar()
    {
        for (int i = _healthBars.Count - 1; i >= 0; i--)
        {
            if (_healthBars[i].enabled)
            {
                _healthBars[i].enabled = false;
                return;
            }
        }
    }
}
