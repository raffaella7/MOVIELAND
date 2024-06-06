using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoint : MonoBehaviour
{

    void Awake()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<InfiniteMovement>())
        {
            Destroy(collision.gameObject);
        }

    }
}
