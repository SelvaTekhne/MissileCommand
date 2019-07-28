using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingBoxes : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.root.gameObject);
    }
}
