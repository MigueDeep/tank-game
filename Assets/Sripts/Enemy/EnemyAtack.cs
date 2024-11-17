using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform positionShell; // Punto de salida de la bala
    public Transform player; // Referencia al Transform del jugador
    private float attackCooldown = 3f; // Tiempo de espera entre ataques (en segundos)
    private float lastAttackTime = -Mathf.Infinity;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // Verifica si ha pasado el tiempo de recarga
        if (Time.time >= lastAttackTime + attackCooldown)
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
        }
    }
}
