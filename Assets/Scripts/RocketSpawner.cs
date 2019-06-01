using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public float cooldown = 5f;
    public GameObject rocket;

    private float timeLeft;
    void Start()
    {
        timeLeft = cooldown;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            GameObject newRocket = Instantiate(rocket, this.transform.position, this.transform.rotation);
            timeLeft = cooldown;
        }
    }
}
