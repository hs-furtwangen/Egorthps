using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public
    public float playerMoveSpeed = 10.0f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

    public float jumpForce = 5.0f;

    private Vector3 rotationVector;

    int perspectiveCharges = 3;
    float distToGround;
    Rigidbody rb;

    PerspectiveSwitcher perspSwitcher;
    bool isUsingPerspectiveViewMode = false;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();

        rotationVector = Vector3.zero;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        perspSwitcher = Camera.main.GetComponent<PerspectiveSwitcher>();

        UpdatePerspectiveChargesText();
    }

    void UpdatePerspectiveChargesText() {
        GameUIManager.Instance.SetPerspectiveChargesText(perspectiveCharges.ToString());
    }

    void Update()
    {
        if (!isUsingPerspectiveViewMode) {
            //Camera Movement
            rotationVector.y += cameraSpeedH * Input.GetAxis("Mouse X");
            rotationVector.x -= cameraSpeedV * Input.GetAxis("Mouse Y");
            transform.rotation = Quaternion.Euler(rotationVector);

            //Player Movement
            rb.MovePosition(rb.position
                + (transform.right * Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime)
                + (transform.forward * Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime));

            //Jumping
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
            }
        }

        //Projection switching
        if (Input.GetMouseButtonDown(1))
        {
            if (perspectiveCharges > 0) {
                perspSwitcher.BlendToPerspective();
                isUsingPerspectiveViewMode = true;
                perspectiveCharges--;
                UpdatePerspectiveChargesText();
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            perspSwitcher.BlendToOrthographic();
            isUsingPerspectiveViewMode = false;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
}
