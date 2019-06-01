using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public GameObject uiCanvas;
    public Camera mainCameraPrefab;

    private GameObject uiCanvasInstance;
    private float startTime;

    void Awake()
    {
        startTime = Time.time;
        uiCanvasInstance = Instantiate(uiCanvas);
        Instantiate(mainCameraPrefab);
    }

    void Update()
    {
        GameUIManager.Instance.SetTimeText(Math.Round(Time.timeSinceLevelLoad, 2).ToString());
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
