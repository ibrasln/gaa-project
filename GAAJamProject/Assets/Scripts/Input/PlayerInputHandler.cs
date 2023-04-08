using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    #region Movement Inputs
    public Vector2 MovementInput { get; private set; }
    public float InputX { get; private set; }
    public float InputY { get; private set; }
    #endregion

    #region Ability Inputs
    public bool RollInput { get; private set; }
    public bool MeleeAttackInput { get; private set; }
    public bool RangeAttackInput { get; private set; }
    #endregion

    public void Move(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        InputX = MovementInput.x;
        InputY = MovementInput.y;
    }

    public void Roll(InputAction.CallbackContext context)
    {
        if (context.started) RollInput = true;
        else if (context.canceled) RollInput = false;
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (context.started) MeleeAttackInput = true;
        if (context.canceled) MeleeAttackInput = false;
    }

    public void RangeAttack(InputAction.CallbackContext context)
    {
        if (context.started) RangeAttackInput = true;
        if (context.canceled) RangeAttackInput = false;
    }
}
