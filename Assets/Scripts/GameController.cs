using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject uiCanvas;
    public Camera mainCameraPrefab;
    public PlayerController playerReference;

    private GameObject uiCanvasInstance;
    private float startTime;

    private float slowTimeScale;

    private AudioSource audioSource;

    void Awake()
    {
        Instance = this;

        audioSource = this.GetComponent<AudioSource>();

        startTime = Time.time;
        uiCanvasInstance = Instantiate(uiCanvas);
        Instantiate(mainCameraPrefab);
    }

    void Update()
    {
        if (playerReference != null && !playerReference.hasFinishedLevel) {
            GameUIManager.Instance.SetTimeText(Math.Round(Time.timeSinceLevelLoad, 2).ToString());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
