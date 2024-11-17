using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Referencia al Transform del jugador
    public float speed = 2f; 
    public float rotationSpeed = 30f; 
    public float stopDistance = 30f; 

    void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Calcula la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si está dentro del rango de movimiento, persigue al jugador
        if (distanceToPlayer > stopDistance)
        {
            // Rotar hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            // Mover hacia el jugador
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
