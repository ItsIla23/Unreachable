using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject WireBuilder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger")) {
            Instantiate(WireBuilder, new Vector3(-0.012f, -0.98f, 11.4f), Quaternion.identity);
        }
    }
}
