using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public
    public float playerSpeed = 10.0f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

    public float jumpForce = 5.0f;

    private Vector3 moveVector;
    private Vector3 rotationVector;

    float distToGround;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();

        moveVector = Vector3.zero;
        rotationVector = Vector3.zero;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        rotationVector.y += cameraSpeedH * Input.GetAxis("Mouse X");
        rotationVector.x -= cameraSpeedV * Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(rotationVector);

        //Player Movement
        moveVector = (transform.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime)
            + (transform.forward * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + moveVector);

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
}
