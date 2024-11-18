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

    public Slider healthBar; // Referencia al slider de la barra de vida

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Configura la barra de vida al inicio
        if (healthBar != null)
        {
            healthBar.maxValue = maxCollisions; // Valor máximo de la barra
            healthBar.value = maxCollisions;   // Valor inicial (vida completa)
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            collisionCount++;

            // Actualiza la barra de vida
            if (healthBar != null)
            {
                healthBar.value = maxCollisions - collisionCount;
            }

            // Si se alcanzan las colisiones máximas, termina el juego
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
            }
        }
    }
}
