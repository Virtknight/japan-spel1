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
        JumpDir = jump.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(Movedir.x * moveSpeed, JumpDir.x * jumpForce, Movedir.y* moveSpeed);    
    }
}
