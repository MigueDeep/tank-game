using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    //variables  globales
    public int speed;
    float xPosition = 0;
    float yPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        float force;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        Debug.Log("X position: " + xPosition);         
        Debug.Log("Y position: " + yPosition);
        
        //Asignar valor a la posicion
        transform.position = new Vector3(8, transform.position.y, transform.position.z);
    }

    void calculateNumber()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
