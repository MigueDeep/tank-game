using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importar para manejar la UI

public class PlayerHealth : MonoBehaviour
{
    private int collisionCount = 0;

    public int maxCollisions = 10;
    public GameObject explosionPrefab;
    private Rigidbody rb;
    public GameObject gameOverPanel;

    public Slider healthBar;
    public GameObject barraVida;

    public AudioSource bombSound; // Componente AudioSource para el sonido de la bomba

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        if (healthBar != null)
        {
            healthBar.maxValue = maxCollisions;
            healthBar.value = maxCollisions;
        }

        // Verificar si el AudioSource está asignado
        if (bombSound == null)
        {
            Debug.LogWarning("El componente AudioSource para bombSound no está asignado.");
        }
        else
        {
            // Ensure the AudioSource is enabled at the start
            bombSound.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si la bala atraviesa al jugador
        if (other.CompareTag("Shell"))
        {
            collisionCount++;

            // Actualiza la barra de vida
            if (healthBar != null)
            {
                healthBar.value = maxCollisions - collisionCount;
            }

            // Destruir la bala al atravesar al jugador
            Destroy(other.gameObject);

            // Verificar si se alcanza el límite de colisiones
            if (collisionCount >= maxCollisions)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                var particleSystem = explosion.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    particleSystem.Play();
                }

                Destroy(gameObject);
                Destroy(explosion, 1);
                gameOverPanel.SetActive(true);
                barraVida.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            
            if (bombSound != null && bombSound.enabled)
            {
                bombSound.Play();
            }
            else
            {
                Debug.LogWarning("No se asignó un AudioSource para bombSound o el AudioSource está deshabilitado.");
            }

            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            var particleSystem = explosion.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            Destroy(other.gameObject);
            Destroy(explosion, 1);
            collisionCount += 2;
            healthBar.value = maxCollisions - collisionCount;
        }

        if (other.gameObject.CompareTag("Life"))
        {
            collisionCount -= 2;
            healthBar.value = maxCollisions - collisionCount;
            Destroy(other.gameObject);
        }
    }
}
