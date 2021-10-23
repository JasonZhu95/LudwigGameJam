using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.audioSources[0].Play();
        player.audioSources[0].UnPause();
    }

    public override void Exit()
    {
        base.Exit();
        player.audioSources[0].Pause();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.canMove)
        {
            player.CheckIfShouldFlip(xInput);

            player.SetVelocityX(playerData.movementVelocity * xInput);

            if (xInput == 0 && !isExitingState)
            {
                stateMachine.ChangeState(player.IdleState);
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
}
