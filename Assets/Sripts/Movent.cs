using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movent : MonoBehaviour
{
    public int speed;
    public int turnSpeed;
    public Light lightTank;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        lightTank = GetComponent<Light>();
    }

    void Update()
    {
        //Vector3.forward = new Vector3(0, 0, 1) -> Eje z
        //Vector3.up = new Vector3(0, 1, 0) -> Eje y
        //Vector3.right = new Vector3(1, 0, 0) -> Eje x
        //Time.deltaTime -> metros por segundo
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontal);

        if (Input.GetKey(KeyCode.F))
        {
            lightTank.enabled = false;

        } 
        
        //Obtener un compornente
        //Ligth light = GetComponent<Light>();
        
        
        // if (Input.GetKey(KeyCode.W))
        // { 
        //     transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // }else if (Input.GetKey(KeyCode.S))
        // {
        //     transform.Translate(Vector3.back * Time.deltaTime * speed);
        // }
        //
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.Rotate( Vector3.up * Time.deltaTime * turnSpeed);
        // } else if (Input.GetKey(KeyCode.A))
        // {
        //     transform.Rotate( Vector3.down * Time.deltaTime * turnSpeed);
        // }
        
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate time: " + Time.deltaTime);
    }
}
