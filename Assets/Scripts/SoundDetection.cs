using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetection : MonoBehaviour
{
    AudioSource audioSource;
    LineRenderer lr;
    public BeatDetection beatDetection; //add GO with the BeatDetection Script in here. Add BD Script to Main Camera
    float cooldown = 0.4f;
    float currentCooldown = 0f;

    Material mat;

    void Start()
    {


        beatDetection.CallBackFunction = OnBeatDetected;

        mat = this.GetComponent<Renderer>().material;
    }

    void OnBeatDetected(BeatDetection.EventInfo eventInfo)
    {
        //eventInfo.messageInfo == BeatDetection.EventType.Kick
        if (currentCooldown < 0 && eventInfo.messageInfo == BeatDetection.EventType.Snare)
        {
            mat.color = Color.HSVToRGB(Random.value, 1, 1);
            currentCooldown = cooldown;
        }
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;

    }
}
