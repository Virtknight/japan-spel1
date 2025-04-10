using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [Header("References")]
    public Rigidbody rb;
    public Camera cam;
    public Transform orientation;
    public InputActionReference move;

    [Header("Gravity-variables")]

    public float gravitationScale = 1;
    public float gravity;
    public float raycastlength;

    [Header("Other-variables")]


    public float moveSpeed;

    public float jumpForce = 10f;

    private Vector2 Movevalue;
    private float timer;

    [SerializeField] private Running running;


    private void Update()
    {
        Movevalue = move.action.ReadValue<Vector2>();


    }
    private void FixedUpdate()
    {
        HandleGravity();
        Move();
        if (GroundCheck())
        {
            timer = 0.5f;
        }

        timer -= Time.deltaTime;
    }


    public void OnJump(InputAction.CallbackContext context)
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
        var targetSpeed = running.isSprinting ? running.speed * running.multiplier : running.speed;
        running.currentSpeed = Mathf.MoveTowards(running.currentSpeed, targetSpeed, running.acceleration * Time.deltaTime);

        var targetFov = running.isSprinting ? running.CamFOV + running.CamIncrease : running.CamFOV;
        running.currentFOV = Mathf.MoveTowards(running.currentFOV, targetFov, running.CamAcceleration*Time.deltaTime);

        cam.fieldOfView = running.currentFOV;
        Vector3 movedirect = orientation.right * Movevalue.x + orientation.forward * Movevalue.y;
        rb.linearVelocity = new Vector3(movedirect.x * running.currentSpeed, rb.linearVelocity.y, movedirect.z * running.currentSpeed);
    }

    bool GroundCheck()
    {
        return Physics.Raycast(rb.position, Vector3.down, raycastlength);

    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        Debug.Log("Im running");
        running.isSprinting = context.started || context.performed;
    }
}

[Serializable]
public struct Running
{
    [Header("Running-variables:")]
    public float speed;
    public float multiplier;
    public float acceleration;

    [Header("FOV-run-variables")]

    public float CamFOV;
    public float CamIncrease;
    public float CamAcceleration;

    [HideInInspector] public bool isSprinting;
    [HideInInspector] public float currentSpeed;

    [HideInInspector] public float currentFOV;
}







