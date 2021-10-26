using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private float _lifetime = 4f;
    [SerializeField] private Weapon weaponToEquip;


    private void Update() {
        Destroy(gameObject, _lifetime);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }
}
