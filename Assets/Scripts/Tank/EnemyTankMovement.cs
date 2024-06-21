using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;

    private Transform player;
    private float nextFireTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
            CheckAttack();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance > attackRange)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void CheckAttack()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackRange && Time.time >= nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Attack()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}
