using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float followRadius = 5f; // Radio de seguimiento
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo

    private Vector3 initialPosition; // Posición inicial del enemigo

    void Start()
    {
        // Guardamos la posición inicial del enemigo
        initialPosition = transform.position;
    }

    void Update()
    {
        // Verificamos la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del radio de seguimiento, movemos al enemigo
        if (distanceToPlayer <= followRadius)
        {
            // Calculamos la dirección hacia el jugador
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Calculamos la nueva posición del enemigo, pero manteniendo el radio
            Vector3 newPosition = transform.position + directionToPlayer * (moveSpeed * Time.deltaTime);

            // Limitamos la posición del enemigo para que no se aleje del radio
            if (Vector3.Distance(newPosition, initialPosition) <= followRadius)
            {
                transform.position = newPosition;
            }
            else
            {
                // Si la nueva posición se sale del radio, se ajusta para no sobrepasarlo
                transform.position = initialPosition + directionToPlayer * followRadius;
            }
        }
    }
}