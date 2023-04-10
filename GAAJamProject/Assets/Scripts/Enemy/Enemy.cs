using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private EnemyState currentState;
    [SerializeField] private float attackCooldown;
    private float attackTimer;

    private Transform academy;

    private bool canAttack = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        attackTimer = attackCooldown;
        academy = GameObject.FindGameObjectWithTag("Academy").transform;
        currentState = EnemyState.MOVE;
    }

    private void Update()
    {
        HandleEnemyState();
    }

    private void HandleEnemyState()
    {
        switch (currentState)
        {
            case EnemyState.MOVE:
                MoveTowardsAcademy();
                break;

            case EnemyState.ATTACK:
                AttackAcademy();
                break;

        }
    }

    private void MoveTowardsAcademy()
    {
        transform.position = Vector2.MoveTowards(transform.position, academy.position, moveSpeed * Time.deltaTime);
        
        if (canAttack)
        {
            currentState = EnemyState.ATTACK;
        }
    }

    private void AttackAcademy()
    {
        if (attackTimer < 0)
        {
            anim.SetBool("idle", false);
            anim.SetTrigger("attack");
            SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Damage);
            academy.GetComponent<Health>().TakeDamage();
            attackTimer = attackCooldown;
        }
        else
        {
            attackTimer -= Time.deltaTime;
            anim.SetBool("idle", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Academy"))
        {
            canAttack = true;
        }
    }
}

public enum EnemyState
{
    MOVE,
    ATTACK
}
