using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsRotation : MonoBehaviour
{
    [SerializeField] public float speed = 0.5f;
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}