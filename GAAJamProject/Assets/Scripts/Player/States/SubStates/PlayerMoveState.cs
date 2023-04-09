using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (xInput == 0 && yInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            player.SetVelocity(xInput * playerData.movementSpeed, yInput *  playerData.movementSpeed);
        }
    }
}
