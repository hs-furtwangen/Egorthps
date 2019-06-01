using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    public float xRotationSpeed = 0.0f;
    public float yRotationSpeed = 0.0f;
    public float zRotationSpeed = 0.0f;

    void Update()
    {
        transform.Rotate(new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed) * Time.deltaTime);
    }
}
