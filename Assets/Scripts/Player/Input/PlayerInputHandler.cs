using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public static int smashBalls = 0;
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public bool InteractInput { get; private set; }
    public bool PauseInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }

    public IInteractable Interactable { get; set; }
    [SerializeField] private TextUI textUI;
    public TextUI TextUI => textUI;

    [SerializeField] private float inputBufferTime = 0.2f;
    private float jumpInputStartTime;
    private float dashInputStartTime;

    public bool disableInputs;

    private void Update()
    {
        CheckJumpInputBufferTime();
        CheckDashInputHoldTime();
        CheckInteractInputTime();
        CheckPauseInputTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            if (Mathf.Abs(RawMovementInput.x) > 0.5f)
            {
                NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
            }
            else
            {
                NormInputX = 0;
            }

            if (Mathf.Abs(RawMovementInput.y) > 0.5f)
            {
                NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
            }
            else
            {
                NormInputY = 0;
            }
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                jumpInputStartTime = Time.time;
            }

            if (context.canceled)
            {
                JumpInputStop = true;
            }
        }
        else
        {
            JumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            if (context.started)
            {
                GrabInput = true;
            }

            if (context.canceled)
            {
                GrabInput = false;
            }
        }
        else
        {
            GrabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            if (context.started)
            {
                DashInput = true;
                DashInputStop = false;
                dashInputStartTime = Time.time;
            }
            else if (context.canceled)
            {
                DashInputStop = true;
            }
        }
        else
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            RawDashDirectionInput = context.ReadValue<Vector2>();
            DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            if (context.started)
            {
                InteractInput = true;
            }

            if (context.canceled)
            {
                InteractInput = false;
            }
        }
        else
        {
            InteractInput = false;
        }
    }
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PauseInput = true;
        }

        if (context.canceled)
        {
            PauseInput = false;
        }
  
    }

    public void UseDashInput() => DashInput = false;
    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputBufferTime()
    {
        if (Time.time >= jumpInputStartTime + inputBufferTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputBufferTime)
        {
            DashInput = false;
        }
    }

    private void CheckInteractInputTime()
    {
        if (Time.time >= inputBufferTime)
        {
            InteractInput = false;
        }
    }

    private void CheckPauseInputTime()
    {
        if (Time.time >= inputBufferTime)
        {
            PauseInput = false;
        }
    }
}
