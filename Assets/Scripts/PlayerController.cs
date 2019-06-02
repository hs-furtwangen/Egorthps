using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public
    public bool debugMode = true;
    public float playerMoveSpeed = 10.0f;

    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

    public float jumpForce = 5.0f;

    public bool hasFinishedLevel = false;

    private Vector3 rotationVector;

    int perspectiveCharges = 3;
    float distToGround;
    Rigidbody rb;

    PerspectiveSwitcher perspSwitcher;
    bool isUsingPerspectiveViewMode = false;

    float regularTimescale = 1;
    float slowTimescale = 0.2f;

    void Start()
    {
        GameController.Instance.playerReference = this;

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
        if (!isUsingPerspectiveViewMode || debugMode) {
            //Camera Movement
            rotationVector.y += cameraSpeedH * Input.GetAxis("Mouse X") * Time.deltaTime;
            rotationVector.x -= cameraSpeedV * Input.GetAxis("Mouse Y") * Time.deltaTime;
            GameObject.FindGameObjectWithTag("VirtualCamera").transform.rotation = Quaternion.Euler(rotationVector);

            Vector3 moveDirection;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection *= playerMoveSpeed;

            //Player Movement
            rb.MovePosition(rb.position + moveDirection * Time.deltaTime);

            //Jumping
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
            }
        }

        //Projection switching
        if (Input.GetMouseButtonDown(1))
        {
            if (perspectiveCharges > 0 || debugMode) {

                perspSwitcher.BlendToPerspective();
                isUsingPerspectiveViewMode = true;

                if (!debugMode) {
                    perspectiveCharges--;
                    UpdatePerspectiveChargesText();
                }
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

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Finish")) {
            gameObject.SetActive(false);
            hasFinishedLevel = true;
        }
    }
}
