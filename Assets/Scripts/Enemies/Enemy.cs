using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    public float Speed;

    [Header("Attack System")]
    public int Damage;
    public float AttackRange;
    public float TimeBetweenAttacks;
    public float AttackSpeed;

    [Header("Drops")]
    [SerializeField] private int dropChance;
    [SerializeField] private GameObject[] drops;

    [HideInInspector] public Transform Player;

    public virtual void Start()
    {
        // Finding Player in scene
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        this._health -= damage;
        // Death
        if (this._health <= 0){
            if (Random.Range(0,101) < dropChance){
                GameObject randomDrop = drops[Random.Range(0,drops.Length)];
                Instantiate(randomDrop, transform.position, transform.rotation);
            }
            Destroy(gameObject);
            }
    }

    public IEnumerator MeleeAttack()
    {
        Player.GetComponent<Player>().TakeDamage(Damage);

        Vector2 selfPosition = transform.position;
        Vector2 targetPosition = Player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * AttackSpeed;
            float f = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(selfPosition, targetPosition, f);
            yield return null;
        }
    }


}
