using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform positionShell; // Punto de salida de la bala
    public Transform player; // Referencia al Transform del jugador
    public AudioSource shootSound; // Referencia al componente AudioSource del enemigo

    private float attackCooldown = 3f; // Tiempo de espera entre ataques (en segundos)
    private float lastAttackTime = -Mathf.Infinity;
    public float maxShootingAngle = 45f; // Ángulo máximo permitido para disparar

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // Verifica si ha pasado el tiempo de recarga
        if (Time.time >= lastAttackTime + attackCooldown && IsPlayerInFront())
        {
            CreateBullet();
            lastAttackTime = Time.time; // Actualiza el momento del último disparo
        }
    }

    void CreateBullet()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - positionShell.position).normalized;

            // Crea la bala
            GameObject bullet = Instantiate(bulletPrefab, positionShell.position, Quaternion.LookRotation(direction));

            // Aplica una fuerza a la bala
            bullet.GetComponent<Rigidbody>().AddForce(direction * 1500);

            // Reproduce el sonido de disparo con menor volumen
            if (shootSound != null)
            {
                shootSound.PlayOneShot(shootSound.clip, 0.2f); // Volumen reducido al 50%
            }
        }
    }

    bool IsPlayerInFront()
    {
        if (player == null) return false;

        // Dirección hacia el jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Calcula el ángulo entre el frente del enemigo y la dirección hacia el jugador
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Retorna true si el ángulo está dentro del rango permitido
        return angle <= maxShootingAngle;
    }
}
