using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private BoxCollider2D bodysensor;
    public bool interactable = false;
    GameObject PauseHandle;
    gamepause pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodysensor = GetComponent<BoxCollider2D>();
        PauseHandle=GameObject.Find("GamePauseHandle");
        if (PauseHandle!=null)
        {
            pause=PauseHandle.GetComponent<gamepause>();
        }
    }

    // Update is called once per frame
    void Update()
    {
         rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(!pause.GAME_PAUSE)
       {
        moveInput = context.ReadValue<Vector2>();
       }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        interactable = true;
        StartCoroutine(DelayedAction());
        Debug.Log("Interacted");
    }
    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(.1f);
        interactable = false;
    }
}

