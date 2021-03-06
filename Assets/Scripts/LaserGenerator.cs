﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour
{
    public float maxRange = 100f;
    public float cooldown = 10f;
    public float duration = 1f;
    public float warmup = 1f;

    public AudioSource loadSound;
    public AudioSource fireSound;

    private float currentTimer = 0f;
    enum LASERPHASE { Cooldown, Warmup, On }

    LASERPHASE phase = LASERPHASE.Cooldown;
    int amountPhases = System.Enum.GetNames(typeof(LASERPHASE)).Length;

    public GameObject laser;
    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mm = ps.main;
        mm.duration = warmup;
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer < 0)
        {
            nextPhase();
            switch (phase)
            {
                case LASERPHASE.Cooldown:
                    loadSound.Stop();
                    fireSound.Stop();
                    laser.transform.localScale = Vector3.zero;
                    currentTimer = cooldown;
                    break;
                case LASERPHASE.Warmup:
                    loadSound.Play();
                    ps.Play();
                    currentTimer = warmup;
                    break;
                case LASERPHASE.On:
                    loadSound.Stop();
                    fireSound.Play();
                    currentTimer = duration;
                    break;
            }
        }
        switch (phase)
        {
            case LASERPHASE.On:
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, maxRange))
                {
                    laser.transform.localScale = new Vector3(1, 1, Vector3.Magnitude(this.transform.position - hit.point));
                } else
                {
                    laser.transform.localScale = new Vector3(1, 1, maxRange);
                }
                break;
        }

    }

    void nextPhase()
    {
        phase++;
        if ((int)phase >= amountPhases) phase = 0;
    }
}
