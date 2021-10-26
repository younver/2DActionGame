using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;


    [SerializeField] private float[] cameraClampers = new float[4];

    private void Start()
    {
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x,
                cameraClampers[0], cameraClampers[1]);
            float clampedY = Mathf.Clamp(playerTransform.position.y,
                cameraClampers[2], cameraClampers[3]);

            transform.position = Vector2.Lerp(transform.position,
                new Vector2(clampedX, clampedY), speed);
        }
    }
}
