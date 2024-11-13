using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public AudioSource bala;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entro al jugador, se sumara una moneda");
            bala.PlayOneShot(bala.clip);
            Destroy(this.gameObject);
        }
    }
}
