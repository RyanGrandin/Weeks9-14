using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LocalMultiplayerController : MonoBehaviour
{
    public Vector2 movementInput;
    public float speed = 5;
    public PlayerInput playerInput;
    public LocalMultiplayerManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + " attacked.");
            manager.PlayerAttacking(playerInput);
        }
    }
}
