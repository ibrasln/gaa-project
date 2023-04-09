public class PlayerGroundedState : PlayerState
{
    protected float xInput;
    protected float yInput;
    protected bool rollInput;
    protected bool meleeAttackInput;
    protected bool rangeAttackInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        #region Inputs
        xInput = player.InputHandler.InputX;
        yInput = player.InputHandler.InputY;
        rollInput = player.InputHandler.RollInput;
        meleeAttackInput = player.InputHandler.MeleeAttackInput;
        rangeAttackInput = player.InputHandler.RangeAttackInput;
        #endregion
    }
}
