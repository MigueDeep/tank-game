using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject explosionPrefab; 

    void OnTriggerEnter(Collider other)
    {
        // Instanciar la explosión en la posición actual de la bala
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        var particleSystem = explosion.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }

        // Destruir la bala y la explosión tras un corto tiempo
        Destroy(gameObject); // Destruye la bala inmediatamente
        Destroy(explosion, 1); // Destruye la explosión después de 1 segundo
    }
}
