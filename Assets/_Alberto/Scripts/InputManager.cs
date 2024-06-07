using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction touch;
    public Vector2 startedPos;
    private Vector2 lastPos;
    PlayerBehaivor playerBehaivor;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touch = playerInput.actions["Move"];
        playerInput = GetComponent<PlayerInput>();
        touch = playerInput.actions["Move"];
        playerBehaivor = FindAnyObjectByType<PlayerBehaivor>();

    }

    // Update is called once per frame
    void OnEnable()
    {
        touch.started += TouchPos1;
        touch.performed += TouchPos2;
        touch.canceled += TouchPos3;
    }


    void TouchPos1(InputAction.CallbackContext context)
    {
        startedPos = context.ReadValue<Vector2>();
        // print(startedPos);
    }

    void TouchPos2(InputAction.CallbackContext context)
    {
        lastPos = context.ReadValue<Vector2>();
        // print(lastPos);
    }
    void TouchPos3(InputAction.CallbackContext context)

    {
        SwipeDirection();
    }


    void SwipeDirection()
    {
        float x = lastPos.x - startedPos.x;
        float y = lastPos.y - startedPos.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
            {
                playerBehaivor.Left();
                // print("swipe left");
            }
            else if (x > 0)
            {
                playerBehaivor.Right();
                // print("swipe right");
            }
        }
        // else
        // {
        // if (y < 0)
        // print("swipe down");
        // else if (y > 0)
        // print("swipe up");
        // }
    }
}
