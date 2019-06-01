using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public
    public float playerSpeed = 10.0f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

    public float jumpForce = 5.0f;

    private Vector3 mov;
    private Vector3 rot;

    float distToGround;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;

        rb = GetComponent<Rigidbody>();

        mov = Vector3.zero;
        rot = Vector3.zero;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        rot.y += cameraSpeedH * Input.GetAxis("Mouse X");
        rot.x -= cameraSpeedV * Input.GetAxis("Mouse Y");
        this.transform.rotation = Quaternion.Euler(rot);

        mov = this.transform.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime + this.transform.forward * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + mov);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Camera.main.orthographic = !Camera.main.orthographic;
        }
    }

    bool IsGrounded() {
    return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
