using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private int _damage;
    [SerializeField] private int pierceAmount = 0;

    [Header("Attributes")]
    [SerializeField] private int _speed;
    [SerializeField] private float _lifeTime;

    [Header("Visuals")]
    [SerializeField] private GameObject _explosionParticle;

    private void Start()
    {
        Invoke("DestroyProjectile", _lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        Instantiate(_explosionParticle, transform.position,
            Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(this._damage);
            if (pierceAmount <= 0)
            {
                DestroyProjectile();
            }
            else
            {
                Instantiate(_explosionParticle, transform.position,
                    Quaternion.identity);
                pierceAmount--;
            }
        }
    }
}
