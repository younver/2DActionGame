using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;


    [SerializeField] private float[] _cameraClampers = new float[4];

    private void Start()
    {
        transform.position = _playerTransform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        float clampedX = Mathf.Clamp(_playerTransform.position.x, 
            _cameraClampers[0], _cameraClampers[1]);
        float clampedY = Mathf.Clamp(_playerTransform.position.y,
            _cameraClampers[2], _cameraClampers[3]);


        if (_playerTransform != null)
            transform.position = Vector2.Lerp(transform.position,
                new Vector2(clampedX, clampedY), _speed);
    }
}
