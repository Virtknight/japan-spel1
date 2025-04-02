using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;

    public float jumpForce;

    private Vector2 Movedir;
    private Vector2 JumpDir;


    public InputActionReference move;
    public InputActionReference jump;

    private void Update()
    {
        Movedir = move.action.ReadValue<Vector2>();

    }

    private void OnJump(InputValue value)
    {
        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

        

    }

    private void FixedUpdate()
    {
        Gravity();
        rb.linearVelocity = new Vector3(Movedir.x * moveSpeed, 0, Movedir.y* moveSpeed);    
    }

    private void Gravity(){
        rb.AddForce(Vector3.down * 9.82f, ForceMode.Acceleration);
    }


    
}
