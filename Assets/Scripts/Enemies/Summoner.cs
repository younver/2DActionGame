using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
    private float _attackTimer;
    private float _summonTimer;
    private Vector2 _targetPosition;

    private Animator animator;

    [Header("Position")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [Header("Summon")]
    public Enemy EnemyToSummon;
    [SerializeField] private float timeBetweenSummons;
    

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();

        // Calculating summoners desired position
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        _targetPosition = new Vector2(randomX, randomY);
    }

    private void Update()
    {
        if (Player != null)
        {
            // Move the summoner if not close enough to desired position
            if(Vector2.Distance(transform.position, _targetPosition) > 0.5f)
            {
                // Running animation
                animator.SetBool("isRunning", true);

                transform.position = Vector2.MoveTowards(transform.position, 
                    _targetPosition, Speed * Time.deltaTime);

            }

            // Start summoning in desired position
            else
            {
                // Setting animator conditions
                animator.SetBool("isRunning", false);

                // Summon
                if (Time.time > _summonTimer)
                {
                    // Cheesy timer trick for handling summon delays
                    _summonTimer = Time.time + timeBetweenSummons;

                    // PS: Using Summon function from animator event in Unity
                    animator.SetTrigger("summon");
                }
            }

            // Attack if player in attack range
            if (Vector2.Distance(transform.position, Player.position) < AttackRange)
            {
                if (Time.time >= _attackTimer)
                {
                    StartCoroutine(MeleeAttack());
                    _attackTimer = Time.time + TimeBetweenAttacks;
                }
            }
        }
    }

    public void Summon()
    {
        if (Player != null)
        {
            Instantiate(EnemyToSummon, transform.position, transform.rotation);
        }
    }

}
