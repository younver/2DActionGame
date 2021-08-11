using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
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
}
