using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;
    public bool isWallGrab;

    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isWallGrab = true;
        holdPosition = player.transform.position;
        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
        isWallGrab = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            HoldPosition();
            if (yInput > 0)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
            else if (yInput < 0 || !grabInput)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
        }
    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;
        player.SetVelocityZero();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
