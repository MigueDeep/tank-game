using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    private float followRadius = 30f; // Radio de seguimiento
    private float rotationSpeed = 8f; // Velocidad de rotación

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

        // Si el jugador está dentro del radio de seguimiento, el enemigo solo girará para mirarlo
        if (distanceToPlayer <= followRadius)
        {
            // Calculamos la dirección hacia el jugador
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Calculamos la rotación que debe tener el enemigo para mirar al jugador
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Rotamos gradualmente el enemigo hacia el jugador
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
