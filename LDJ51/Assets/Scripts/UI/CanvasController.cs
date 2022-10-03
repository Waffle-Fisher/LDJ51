using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    List<Canvas> canvasList = new List<Canvas>();

    private void Awake()
    {
        if(Instance == null) { Instance = this; }
        else { Destroy(Instance); }
    }
    void Start()
    {
        GetComponentsInChildren<Canvas>(canvasList);
        EnableCanvas(0);
    }

    public void EnableCanvas(int i)
    {
        foreach(Canvas c in canvasList)
        {
            c.enabled = false;
        }
        canvasList[i].enabled = true;
    }
}
