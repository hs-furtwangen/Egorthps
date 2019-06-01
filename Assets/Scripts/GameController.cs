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

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //uiCanvasInstance = Instantiate(uiCanvas);
        Instantiate(mainCameraPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //uiCanvasInstance.GetComponent<UIManager>().timeText.text = Math.Round(Time.timeSinceLevelLoad, 2).ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
