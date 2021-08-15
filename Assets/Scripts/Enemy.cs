using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;


    public float Speed;
    public float TimeBetweenAttacks;
    public int Damage;

    [HideInInspector] public Transform Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        this._health -= damage;
        if (this._health <= 0)
            Destroy(gameObject);
    }
    

}
