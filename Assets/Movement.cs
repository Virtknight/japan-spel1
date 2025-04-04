using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;

    public float jumpForce = 10f;

    public float gravitationScale = 1;
    public float gravity;
    public float raycastlength;

    private Vector2 Movedir;
    private Vector2 JumpDir;

    public Camera cam;


    public InputActionReference move;
    public InputActionReference jump;

    private void Update()
    {
        Movedir = move.action.ReadValue<Vector2>();


    }

    

    private void OnJump(InputValue value)
    {
        if(GroundCheck()){
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        

    }

    private void FixedUpdate()
    {
        HandleGravity();
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

        // SetYLevelAccordingToGravity();



            bool GroundCheck(){
        return Physics.Raycast(rb.position, Vector3.down, raycastlength);
        
    }
    }




    

