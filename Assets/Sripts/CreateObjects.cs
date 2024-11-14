using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform posRotShell;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            createSphere();
        }

        void createSphere() {
            Instantiate(shellPrefab, posRotShell.position, posRotShell.rotation);
        }
    }
}
