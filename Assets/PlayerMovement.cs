using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float cameraMoveSpeed = 0.1f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

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

        Vector2 positionVector = transform.position;

        //Player body movement
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 position = rigidbody.position;
        position = position + new Vector3(xAxis, 0, zAxis) * playerSpeed * Time.deltaTime;
        rigidbody.MovePosition(position);
    }
}
