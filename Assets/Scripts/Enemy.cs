using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        this._health -= damage;
        if (this._health <= 0)
            Destroy(gameObject);
    }
    

}
