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
    public int FacingDirection { get; private set; }

    private Camera cam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private PlayerDataSO playerData;
    private Vector2 workspace;
    [SerializeField] private float attackCooldown = .75f;
    private float attackTimer;
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
        cam = Camera.main;
        StateMachine = new();
    }

    private void Start()
    {
        attackTimer = attackCooldown;
        IdleState = new(this, StateMachine, playerData, "idle");
        MoveState = new(this, StateMachine, playerData, "move");

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        Debug.Log(StateMachine.CurrentState);
        CurrentVelocity = RB.velocity;

        if (InputHandler.RangeAttackInput && attackTimer < 0)
        {
            RangeAttack();
            attackTimer = attackCooldown;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
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

    public void Flip(float xInput)
    {
        if (xInput > 0.5f)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new(-1, 1, 1);
        }
    }

    public void RangeAttack()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Attack);

        GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * 14f;
    }
}
