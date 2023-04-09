using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private EnemyState currentState;

    private Transform academy;

    private bool canAttack = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Academy"))
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
