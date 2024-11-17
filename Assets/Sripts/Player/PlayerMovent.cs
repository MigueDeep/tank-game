using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 30f;
    float h;
    float v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Movement();
    }

    void InputPlayer(){
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void Movement(){
        
        transform.Translate(Vector3.forward * speed * v * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * h * Time.deltaTime);

    }
}
