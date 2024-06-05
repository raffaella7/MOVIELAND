using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAll : MonoBehaviour
{
    // Start is called before the first frame update
    bool isRotating = false;
    void Start()
    {
        StartCoroutine(RotateAllParts());
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
            transform.Rotate(Vector3.up * Time.deltaTime * 2.5f);
    }

    IEnumerator RotateAllParts()
    {
        //wait 17s and then start slow rotation over 120s
        yield return new WaitForSeconds(16f);
        isRotating = true;

    }
}
