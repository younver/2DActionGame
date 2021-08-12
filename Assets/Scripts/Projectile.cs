using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int PierceAmount = 0;


    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;
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
            if (PierceAmount <= 0) DestroyProjectile();
            else PierceAmount--;
        }
    }
}
