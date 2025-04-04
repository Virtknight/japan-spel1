using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;

    public float moveSpeed;
    public float SprintIncrease;

    public float jumpForce = 10f;

    public float gravitationScale = 1;
    public float gravity;
    public float raycastlength;

    private Vector2 Movevalue;

    public Camera cam;

    public Transform orientation;

    public InputActionReference move;

    private float timer;


    private void Update()
    {
        Movevalue = move.action.ReadValue<Vector2>();


    }
    private void FixedUpdate()
    {
        HandleGravity();
        Move();

        if(GroundCheck()){
            timer = 0.5f;
        }

        timer -= Time.deltaTime;
    }


    private void OnJump(InputValue value)
    {
        if (timer > 0)
        {
            // rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            timer = 0;
        }


    }

    void HandleGravity()
    {
        bool isGrounded = GroundCheck();

        Debug.Log(GroundCheck());
        if (!isGrounded)
        {
            rb.AddForce(new Vector3(0, -gravity * gravitationScale, 0), ForceMode.Force);
        }

    }
    void Move()
    {
        Vector3 movedirect = orientation.right * Movevalue.x + orientation.forward * Movevalue.y;
        rb.linearVelocity = new Vector3(movedirect.x * moveSpeed, rb.linearVelocity.y, movedirect.z* moveSpeed); 
    }

    bool GroundCheck()
    {
        return Physics.Raycast(rb.position, Vector3.down, raycastlength);

    }
}






