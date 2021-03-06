using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.audioSources[2].Play();
        player.audioSources[2].UnPause();
    }

    public override void Exit()
    {
        base.Exit();
        player.audioSources[2].Pause();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (yInput == 1)
            {
                player.SetVelocityY(playerData.wallClimbVelocity);
            }

            if (yInput == -1)
            {
                player.SetVelocityY(-playerData.wallClimbVelocity);
            }

            if (yInput == 0)
            {
                stateMachine.ChangeState(player.WallGrabState);
            }

        }
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
