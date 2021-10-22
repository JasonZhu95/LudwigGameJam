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
    private MenuScript ms;
    private GameObject canvas;
    private GameObject dialogueCanvas;
    private DisplayConversation ds;

    [SerializeField] private float inputBufferTime = 0.2f;
    private float jumpInputStartTime;
    private float dashInputStartTime;

    private float UITimer = 0.0f;
    public float UITimeBuffer = 0.5f;
    public bool canPause = false;
    public bool canInteract = false;


    public bool disableInputs;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        ms = canvas.GetComponent<MenuScript>();

        if(GameObject.FindGameObjectsWithTag("Dialogue Canvas").Length > 0)
        {
            dialogueCanvas = GameObject.FindGameObjectWithTag("Dialogue Canvas");
            ds = dialogueCanvas.GetComponent<DisplayConversation>();
        }
        
    }
    private void Update()
    {
        CheckJumpInputBufferTime();
        CheckDashInputHoldTime();
        

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


    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (!disableInputs)
        {
            if (context.started) 
            { 
                if (GameObject.FindGameObjectsWithTag("Dialogue Canvas").Length == 1)
                {
                    ds.AdvanceConversation();
                }
                InteractInput = true;
            }
            if (context.canceled)
            {
                InteractInput = false;
            }
        }
    }
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(ms.isPaused)
            {
                ms.ResumeGame();
            }
            else if (!ms.isPaused)
            {
                ms.PauseGame();
            }
        }
       
        
    }

    //private void CheckPauseInputTime()
    //{
    //    UITimer += Time.deltaTime;
    //    if (UITimer >= UITimeBuffer)
    //    {
    //        PauseInput = false;
    //    }
    //    else
    //    {
    //        canPause = false;
    //    }
    //}

    //private void CheckInteractInputTime()
    //{
    //    if (Time.time >= UITimer + UITimeBuffer)
    //    {
    //        InteractInput = false;
    //    }
    //}

}
