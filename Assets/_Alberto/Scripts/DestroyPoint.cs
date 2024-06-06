using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoint : MonoBehaviour
{

    void Awake()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        // print("collisione");
        if (other.gameObject.GetComponent<InfiniteMovement>())
        {
            Destroy(other.gameObject);
        }

    }
}
