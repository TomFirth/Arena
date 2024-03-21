using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeDirectionInterval = 1f;

    private Rigidbody rb;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = changeDirectionInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ChangeDirection();
            timer = changeDirectionInterval;
        }

        if (rb.velocity.magnitude > 0.1f)
        {
            Vector3 direction = rb.velocity.normalized;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    void ChangeDirection()
    {
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.y = 0f;

        rb.velocity = randomDirection.normalized * moveSpeed;
    }
}