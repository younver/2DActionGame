using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _attackSpeed;


    private float attackTime;
    
    private void Update()
    {
        if (Player != null)
        {
            if (Vector2.Distance(transform.position, Player.position) > _stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            } else {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + TimeBetweenAttacks;
                }
            }
        }

        
    }

    IEnumerator Attack()
    {
        Player.GetComponent<Player>().TakeDamage(Damage);

        Vector2 selfPosition = transform.position;
        Vector2 targetPosition = Player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * _attackSpeed;
            float f = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(selfPosition, targetPosition, f);
            yield return null;
        }
    }
}
