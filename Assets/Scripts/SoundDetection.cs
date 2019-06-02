using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetection : MonoBehaviour
{
    AudioSource audioSource;
    LineRenderer lr;
    public BeatDetection beatDetection; //add GO with the BeatDetection Script in here. Add BD Script to Main Camera
    // float cooldown = 0.4f;
    // float currentCooldown = 0f;
    BeatCube beatCube;
    BeatUi beatUi;

    void Start()
    {
        beatDetection = GameObject.FindGameObjectWithTag("GameController").GetComponent<BeatDetection>();

        beatCube = this.GetComponent<BeatCube>();
        beatUi = this.GetComponent<BeatUi>();

        beatDetection.CallBackFunction += OnBeatDetected;
    }

    void OnBeatDetected(BeatDetection.EventInfo eventInfo)
    {
        beatCube?.NextColor();
        beatUi?.NextColor();
    }
}
