using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 7f;    
    private float turnSpeed = 50f; 
    private float h;            
    private float v;              
    private Rigidbody rb;

    void Start()
    {
        // Obtén el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Verifica que el Rigidbody esté presente
        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el Player.");
        }
    }

    void Update()
    {
        InputPlayer();
        Movement();
    }

    void InputPlayer()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * turnSpeed * Time.deltaTime);

        // // Movimiento hacia adelante o atrás
        // Vector3 movement = transform.forward * v * speed * Time.fixedDeltaTime;

        // // Rotación
        // Quaternion rotation = Quaternion.Euler(0f, h * turnSpeed * Time.fixedDeltaTime, 0f);

        // rb.Move(rb.position + movement, rb.rotation * rotation);
    }
}
