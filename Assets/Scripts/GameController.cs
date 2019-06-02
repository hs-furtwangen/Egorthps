using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject uiCanvas;
    public Camera mainCameraPrefab;
    public PlayerController playerReference;

    private GameObject uiCanvasInstance;
    private float startTime;

    void Awake()
    {
        Instance = this;

        startTime = Time.time;
        uiCanvasInstance = Instantiate(uiCanvas);
        Instantiate(mainCameraPrefab);
    }

    void Update()
    {
        if (!playerReference.hasFinishedLevel) {
            GameUIManager.Instance.SetTimeText(Math.Round(Time.timeSinceLevelLoad, 2).ToString());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
