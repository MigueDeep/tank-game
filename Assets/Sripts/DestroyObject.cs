using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour


{
    //Metodo que se forma de manera automatica al dar click izq al raton sobre un gameObject que teine un collider
    private void OnMouseDown()
    {
        Debug.Log("Destruimos el objeto");
        Destroy(gameObject);
    }
}
