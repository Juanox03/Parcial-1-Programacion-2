using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke("Hide", 0.5f);
    }

    private void Hide()
    {
        transform.position = new Vector3(2.2f, 0, 6.5f);
    }
}
