using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(PlayerInputHandler))]
public class Player : MonoBehaviour
{
    #region COMPONENTS
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region OTHER VARIABLES
    public PlayerStateMachine StateMachine { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    [SerializeField] private PlayerDataSO playerData;
    private Vector2 workspace;
    #endregion

    #region STATES
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region BUILT-IN FUNCTIONS
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        StateMachine = new();
    }

    private void Start()
    {
        IdleState = new(this, StateMachine, playerData, "idle");
        MoveState = new(this, StateMachine, playerData, "move");

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        Debug.Log(StateMachine.CurrentState);
        CurrentVelocity = RB.velocity;
    }
    #endregion

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #region SET FUNCTIONS
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        workspace = new(xVelocity, yVelocity);
        RB.velocity = workspace;
    }

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
    }
    #endregion
}
