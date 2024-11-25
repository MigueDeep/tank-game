using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa TextMeshProUGUI

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform positionShell; // Punto de salida de la bala
    public TextMeshProUGUI ammunitionText; // Referencia al texto de la UI para la munición
    private int currentAmmo = 10; // Munición inicial
    private float attackCooldown = 1f; // Tiempo de espera entre ataques (en segundos)
    private float lastAttackTime = -Mathf.Infinity; // Momento del último ataque

    void Start()
    {
        UpdateAmmoUI(); // Actualiza el contador al inicio
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // Si se presiona el botón de disparo, hay munición disponible y se cumple el cooldown
        if (Input.GetButtonDown("Fire1") ||  Input.GetKeyDown(KeyCode.P) && currentAmmo > 0 && Time.time >= lastAttackTime + attackCooldown)
        {
            CreateBullet();
            currentAmmo--; // Reduce la munición
            lastAttackTime = Time.time;
            UpdateAmmoUI(); // Actualiza la UI
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, positionShell.position, positionShell.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(positionShell.forward * 1500);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si recoge munición
        if (other.gameObject.CompareTag("Ammunition"))
        {
            currentAmmo += 3; // Incrementa munición (ajusta según tu diseño)
            UpdateAmmoUI(); // Actualiza la UI
            Destroy(other.gameObject); // Elimina el objeto de munición
        }
    }

    void UpdateAmmoUI()
    {
        // Actualiza el texto de la UI para reflejar la munición actual
        ammunitionText.text = $"{currentAmmo}";
    }
}
