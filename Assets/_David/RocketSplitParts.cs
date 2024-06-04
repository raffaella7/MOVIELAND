using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSplitParts : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
            print(child.name);

    }

}
