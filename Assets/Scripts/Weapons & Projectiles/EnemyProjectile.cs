using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private int damage;
    [Header("Attributes")]
    [SerializeField] private int speed;
    [SerializeField] private float lifetime;
    [Header("Visuals")]
    [SerializeField] private GameObject explosionParticle;

    private void Start()
    {
        // Call DestroyProjectile function in lifetime second(s)
        Invoke("DestroyProjectile", lifetime);
    }

    private void Update()
    {
        // Move projectile upwards(not global)
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        // Spawn particles at projectile position with projectile rotation
        Instantiate(explosionParticle, transform.position,
            Quaternion.identity);

        // Destroy projectile
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collided with Player, let them take damage
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
