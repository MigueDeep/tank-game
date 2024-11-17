using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int collisionCount = 0; 
    public int maxCollisions = 3;  
    public GameObject explosionPrefab; 
    private Rigidbody rb;   
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            collisionCount++;

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
            }
        }
    }
}
