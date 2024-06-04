using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSplitParts : MonoBehaviour
{
    Vector3[] newPositions;
    [SerializeField] GameObject SplitRocket;

    void Awake()
    {
        newPositions = new Vector3[SplitRocket.transform.childCount];
        for (int i = 0; i < SplitRocket.transform.childCount; i++)
        {
            newPositions[i] = SplitRocket.transform.GetChild(i).transform.localPosition;
            print(newPositions[i] + " " + SplitRocket.transform.GetChild(i).name);
        }
        SplitRocket.SetActive(false);
    }

    void Start()
    {


    }

}