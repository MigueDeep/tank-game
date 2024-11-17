using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab; 

    void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        var particleSystem = explosion.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }

        Destroy(gameObject);
        Destroy(explosion, 1);
    }
}
