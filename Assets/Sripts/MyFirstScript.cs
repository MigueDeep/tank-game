using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    private int life;

    private int power;
    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        power = 50;
        Debug.Log("Hello dev");
        Debug.Log("Life: " + life);
        calcualteNumber();
    }

    void calcualteNumber()
    {
        Debug.Log("El valor es de: " + life + power);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
