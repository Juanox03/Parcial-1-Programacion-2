using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>())
        {
            StartCoroutine(crDeactive());
        }
    }

    private IEnumerator crDeactive()
    {
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        
        yield return null;
    }
}
