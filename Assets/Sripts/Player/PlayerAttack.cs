using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform positionShell; // Punto de salida de la bala
    private float attackCooldown = 1f; // Tiempo de espera entre ataques (en segundos)
    private float lastAttackTime = -Mathf.Infinity; // Momento del último ataque

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= lastAttackTime + attackCooldown)
        {
            CreateBullet();
            lastAttackTime = Time.time; 
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, positionShell.position, positionShell.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(positionShell.forward * 1500);
    }
}
