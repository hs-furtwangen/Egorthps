using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public GameObject uiCanvas;
    public Camera mainCameraPrefab;
    public PlayerController playerReference;

    private GameObject uiCanvasInstance;
    private float startTime;

    private float slowTimeScale;

    private AudioSource audioSource;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        audioSource = this.GetComponent<AudioSource>();

        startTime = Time.time;
        uiCanvasInstance = Instantiate(uiCanvas);
        Instantiate(mainCameraPrefab);
    }

    void Update()
    {
        if (playerReference != null && !playerReference.hasFinishedLevel)
        {
            GameUIManager.Instance.SetTimeText(Math.Round(Time.timeSinceLevelLoad, 2).ToString());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
