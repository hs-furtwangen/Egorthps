using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public
    public float playerSpeed = 10.0f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;
    public Camera playerCamera;

    //Private
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        yaw += cameraSpeedH * Input.GetAxis("Mouse X");
        pitch -= cameraSpeedV * Input.GetAxis("Mouse Y");
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //Player body movement
        Vector3 position = rigidbody.position;

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 targetDirection = new Vector3(xAxis, 0f, zAxis);
        targetDirection = playerCamera.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;

        position = position + targetDirection * playerSpeed * Time.deltaTime;
        rigidbody.MovePosition(position);
    }
}
