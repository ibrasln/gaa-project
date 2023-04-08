using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class Player : MonoBehaviour
{
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        StateMachine = new();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();

        CurrentVelocity = RB.velocity;
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        workspace = new(xVelocity, yVelocity);
        RB.velocity = workspace;
    }
}
