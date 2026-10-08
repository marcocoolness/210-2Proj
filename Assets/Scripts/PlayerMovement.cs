using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private BoxCollider2D bodysensor;
    private bool interactable = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodysensor = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void Interact(InputAction.CallbackContext context)
    {
        interactable = true;
    }

}

