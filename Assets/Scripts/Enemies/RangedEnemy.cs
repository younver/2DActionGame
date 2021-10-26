using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private float _attackTimer;

    private Animator animator;

    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject ammo;

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Player != null)
        {
            // Move the enemy 'till player in its attack range
            if (Vector2.Distance(transform.position, Player.position) > AttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, 
                    Player.position, Speed * Time.deltaTime);
            }

            // Attack in attack range
            else if (Time.time >= _attackTimer)
            {
                _attackTimer = Time.time + TimeBetweenAttacks;

                // Triggering "attack" from animator calls an event RangedAttack (which setted up from animator)
                animator.SetTrigger("attack");
            }
        }
    }

    public void RangedAttack()
    {
        // Calculating the rotation of ammunition
        Vector2 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        // Spawning of ammunition
        Instantiate(ammo, shotPoint.position, shotPoint.rotation);
    }
}
