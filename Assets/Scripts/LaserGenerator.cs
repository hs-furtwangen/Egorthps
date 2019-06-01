using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour
{
    float maxRange = 100f;
    float cooldown = 10f;
    float duration = 1f;
    float warmup = 1f;
    float currentTimer = 0f;

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
                    laser.transform.localScale = Vector3.zero;
                    currentTimer = cooldown;
                    break;
                case LASERPHASE.Warmup:
                    ps.Play();
                    currentTimer = warmup;
                    break;
                case LASERPHASE.On:
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
        Debug.Log(phase);
    }
}
