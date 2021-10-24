using System;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerLookUpState LookUpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }

    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    //gets current velocity of player
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    public bool canMove;
    [HideInInspector] public bool disableVelocitySet;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform cornerCheck;

    [SerializeField] private PlayerData playerData;

    public ParticleSystem jumpDust;
    public ParticleSystem dashDust;
    public ParticleSystem slideDust;
    public ParticleSystem wallJumpDust;
    public ParticleSystem turnDust;
    public ParticleSystem landDust;

    private Vector2 temporaryWorkspace;
    [HideInInspector] public bool hasHat;
    [HideInInspector]public bool trampolineHatCheck;

    public GameObject[] birds;

    public AudioSource[] audioSources;
    private Color colorTemp;

    //Corner Dash Correction
    private bool cornerDetected;
    private Vector2 cornerPosBot;
    private Vector2 cornerPos1;
    private bool fixCornerDash;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        LookUpState = new PlayerLookUpState(this, StateMachine, playerData, "lookUp");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");
        if (gameObject.transform.GetChild(3).gameObject.name == "HatCheck")
        {
            hasHat = true;
        }
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        FacingDirection = 1;

        StateMachine.Initialize(IdleState);
        audioSources = GetComponents<AudioSource>();
        audioSources[0].Pause();
        audioSources[1].Pause();
        audioSources[2].Pause();

    }

    private void Update()
    {
        //Stop player movements and inputs
        if (!MenuScript.stopPlayerStates)
        {
            CurrentVelocity = RB.velocity;
            StateMachine.CurrentState.LogicUpdate();
            if (InputHandler.disableInputs)
            {
                SetVelocityX(-5f);
            }
        }
        //Bird Color
        if (hasHat && DashState.dashCount == 0)
        {
            birds[0].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
            birds[1].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            birds[2].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else if (hasHat && DashState.dashCount == 1)
        {
            birds[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            birds[1].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            birds[2].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
        else if (hasHat && DashState.dashCount == 2)
        {
            birds[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            birds[1].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            birds[2].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
        else if (!hasHat && DashState.dashCount == 0)
        {
            birds[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            birds[1].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            birds[2].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
        else if (!hasHat && DashState.dashCount == 1)
        {
            birds[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            birds[1].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            birds[2].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }

        //Corner Dash Correction
        if (!CheckIfTouchingWall() && CheckIfTouchingCorner() && !cornerDetected)
        {
            cornerDetected = true;
            cornerPosBot = cornerCheck.position;
        }
        else
        {
            cornerDetected = false;
        }

        CheckCornerFix();
        //Hat Check
        if (gameObject.transform.GetChild(3).gameObject.name == "HatCheck")
        {
            hasHat = true;
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        if (!disableVelocitySet)
        {
            temporaryWorkspace.Set(velocity, CurrentVelocity.y);
            RB.velocity = temporaryWorkspace;
            CurrentVelocity = temporaryWorkspace;
        }
    }

    public void SetVelocityY(float velocity)
    {
        if (!disableVelocitySet)
        {
            temporaryWorkspace.Set(CurrentVelocity.x, velocity);
            RB.velocity = temporaryWorkspace;
            CurrentVelocity = temporaryWorkspace;
        }
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        if (!disableVelocitySet)
        {
            angle.Normalize();
            temporaryWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
            RB.velocity = temporaryWorkspace;
            CurrentVelocity = temporaryWorkspace;
        }
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        if (!disableVelocitySet)
        {
            temporaryWorkspace = direction * velocity;
            RB.velocity = temporaryWorkspace;
            CurrentVelocity = temporaryWorkspace;
        }
    }

    public void SetVelocityZero()
    {
        if (!disableVelocitySet)
        {
            RB.velocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
        }
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance,
            playerData.whatIsGround);
    }

    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -FacingDirection, playerData.wallCheckDistance,
            playerData.whatIsGround);
    }

    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance,
            playerData.whatIsGround);
    }

    public bool CheckIfTouchingCorner()
    {
        return Physics2D.Raycast(cornerCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance,
            playerData.whatIsGround);
    }

    private void CheckCornerFix()
    {
        if (cornerDetected && DashState.isDashing)
        {
            fixCornerDash = true;
            if (FacingDirection == 1)
            {
                cornerPos1 = new Vector2(Mathf.Floor(cornerPosBot.x + playerData.wallCheckDistance) + playerData.cornerFixXOffset1,
                    Mathf.Floor(cornerPosBot.y) + playerData.cornerFixYOffset1);
            }
            else {
                cornerPos1 = new Vector2(Mathf.Ceil(cornerPosBot.x - playerData.wallCheckDistance) - playerData.cornerFixXOffset1,
                    Mathf.Floor(cornerPosBot.y) + playerData.cornerFixYOffset1);
            }
        }

        if (fixCornerDash)
        {
            transform.position = cornerPos1;
            fixCornerDash = false;
        }
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        if (CheckIfGrounded())
        {
            turnDust.Play();
        }
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D HitX = Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection,
            playerData.wallCheckDistance, playerData.whatIsGround);
        float DistX = HitX.distance;
        temporaryWorkspace.Set(DistX * FacingDirection, 0f);
        RaycastHit2D HitY = Physics2D.Raycast(ledgeCheck.position + (Vector3)(temporaryWorkspace), Vector2.down,
            ledgeCheck.position.y - wallCheck.position.y, playerData.whatIsGround);
        float DistY = HitY.distance;
        temporaryWorkspace.Set(wallCheck.position.x + (DistX * FacingDirection), ledgeCheck.position.y - DistY);
        return temporaryWorkspace;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, playerData.groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position,
            new Vector3(wallCheck.position.x + playerData.wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(wallCheck.position,
            new Vector3(wallCheck.position.x - playerData.wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(ledgeCheck.position,
            new Vector3(ledgeCheck.position.x + playerData.wallCheckDistance, ledgeCheck.position.y, ledgeCheck.position.z));
    }
}
