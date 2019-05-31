using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public
    public float playerSpeed = 10.0f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

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
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //Player body movement
        Vector3 position = rigidbody.position;

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        position = position + new Vector3(xAxis, 0, zAxis) * playerSpeed * Time.deltaTime;
        rigidbody.MovePosition(position);
    }
}
