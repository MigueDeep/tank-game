using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    private void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "Wall" || col.gameObject.tag == "Shell" || col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
