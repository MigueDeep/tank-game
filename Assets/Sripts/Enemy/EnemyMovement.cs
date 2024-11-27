using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    private float separationRadius = 70f; // Distancia mínima entre enemigos
    private float separationForce = 70f; // Fuerza para separarlos

    NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            ApplySeparation();
        }
    }

    void ApplySeparation()
    {
        // Obtén todos los enemigos en la escena
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject otherEnemy in enemies)
        {
            if (otherEnemy != this.gameObject) // No te compares contigo mismo
            {
                float distance = Vector3.Distance(transform.position, otherEnemy.transform.position);

                if (distance < separationRadius) // Si están demasiado cerca
                {
                    // Calcula una dirección de separación
                    Vector3 direction = transform.position - otherEnemy.transform.position;
                    direction.Normalize();

                    // Aplica la fuerza de separación
                    transform.position += direction * separationForce * Time.deltaTime;
                }
            }
        }
    }
}