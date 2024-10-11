using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["Position"];
        touchPressAction = playerInput.actions["Click"];

    }

    private void Update()
    {
        Debug.Log(touchPressAction.WasPerformedThisFrame());    
    }
}
