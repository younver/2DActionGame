using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shotDelay;

    private float _shotTime;

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0) && Time.time >= _shotTime)
        {
            Instantiate(_projectile, _shotPoint.position, 
                transform.rotation);
            _shotTime = Time.time + _shotDelay;
        }
            
    }
}
