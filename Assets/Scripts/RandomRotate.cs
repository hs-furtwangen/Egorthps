using UnityEngine;
using System;

public class RandomRotate : MonoBehaviour
{
    public float xRotationSpeedMax, xRotationSpeedMin;
    public float yRotationSpeedMax, yRotationSpeedMin;
    public float zRotationSpeedMax, zRotationSpeedMin;


    private float xRotationSpeed;
    private float yRotationSpeed;
    private float zRotationSpeed;

    void Start() {
        UnityEngine.Random.InitState(gameObject.GetInstanceID());
        xRotationSpeed = UnityEngine.Random.Range(xRotationSpeedMin, xRotationSpeedMax);
        yRotationSpeed = UnityEngine.Random.Range(yRotationSpeedMin, yRotationSpeedMax);
        zRotationSpeed = UnityEngine.Random.Range(zRotationSpeedMin, zRotationSpeedMax);
    }

    void Update()
    {
        transform.Rotate(new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed) * Time.deltaTime);
    }
}
