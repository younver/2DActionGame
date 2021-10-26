using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private float _attackTimer;
    
    private void Update()
    {
        if (Player != null)
        {
            if (Vector2.Distance(transform.position, Player.position) > AttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            } 
            else {
                if (Time.time >= _attackTimer)
                {
                    StartCoroutine(MeleeAttack());
                    _attackTimer = Time.time + TimeBetweenAttacks;
                }
            }
        }

        
    }
}
