using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RocketPartSelect : MonoBehaviour
{
    // Vector3[] newPositions;
    // [SerializeField] GameObject SplitRocket;
    public Camera mainCamera;
    [SerializeField] GameObject Rocket;
    bool isTouchingPart = false;


    void Awake()
    {
        //     newPositions = new Vector3[SplitRocket.transform.childCount];
        //     for (int i = 0; i < SplitRocket.transform.childCount; i++)
        //     {
        //         newPositions[i] = SplitRocket.transform.GetChild(i).transform.localPosition;
        //         print(newPositions[i] + " " + SplitRocket.transform.GetChild(i).name);
        //     }
        //     SplitRocket.SetActive(false);

    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;


        Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
        List<string> tags = new() { "Fairing", "Hub", "LowMain", "SecondStage", "StageSep1", "StageSep2", "ThirdStager", "Thruster", "TopMain" };

        if (Physics.Raycast(ray, out RaycastHit hit, 1000000))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (tags.Contains(hit.collider.gameObject.tag))
                {
                    isTouchingPart = true;
                    for (int i = 0; i < Rocket.transform.childCount; i++)
                    {
                        if (hit.collider.gameObject != Rocket.transform.GetChild(i).gameObject)
                        {
                            Rocket.transform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
        else
        {
            isTouchingPart = false;
            for (int i = 0; i < Rocket.transform.childCount; i++)
            {
                Rocket.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

}