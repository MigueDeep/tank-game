using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para usar elementos UI

public class EnemyHealth : MonoBehaviour
{
    private int collisionCount = 0;
    public int maxCollisions = 3; // Máxima cantidad de colisiones antes de destruir al enemigo
    public GameObject explosionPrefab; // Prefab de explosión
    public Slider healthBar; // Referencia a la barra de vida UI
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        if (healthBar != null)
        {
            // Inicializa la barra de vida
            healthBar.maxValue = maxCollisions;
            healthBar.value = maxCollisions;
        }
    }

   public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            collisionCount++;

            if (healthBar != null)
            {
                // Actualiza la barra de vida
                healthBar.value = maxCollisions - collisionCount;
            }

            if (collisionCount >= maxCollisions)
            {
                // Crear explosión y destruir al enemigo
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                var particleSystem = explosion.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    particleSystem.Play();
                }

                // Notificar al GameManager que el enemigo fue destruido
                GameManager.Instance.EnemyDestroyed();

                Destroy(gameObject);
                Destroy(explosion, 1);
            }
        }
    }

}
