using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using static UnityEngine.Rendering.DebugUI;

public class RocketPartSelect : MonoBehaviour
{
    // Vector3[] newPositions;
    // [SerializeField] GameObject SplitRocket;
    public Camera mainCamera;
    [SerializeField] GameObject Rocket;
    bool isTouchingPart = false;
    Vector3 partStartPosition;
    GameObject selectedPart;
    [SerializeField] List<GameObject> rocketParts = new();
    Dictionary<string, Vector3> tags_pos = new();
    Dictionary<string, Vector3> parts_camera_pos = new Dictionary<string, Vector3>() {
        { "Fairing", new Vector3(0.00013480644f,1.11699998f,-2.43199992f) },
        { "Hub", new Vector3(0.000971867994f,1.17700005f,-2.66400003f) },
        { "LowMain", new Vector3(0.000359554251f,1.86800003f,-2.00600004f) },
        { "SecondStage", new Vector3(-0.00077135762f,1.53400004f,-2.0309999f) },
        { "StageSep1", new Vector3(0,1.65900004f,-2.24900007f) },
        { "StageSep2", new Vector3(0.000464718236f,1.24000001f,-2.4289999f) },
        { "ThirdStager", new Vector3(-0.000771357561f,1.39300001f,-2.19099998f) },
        { "Thruster", new Vector3(0.000464718236f,1.11000001f,-2.49499989f) },
        { "TopMain", new Vector3(-0.0565884896f,1.61899996f,-2.36800003f) },
    };


    void Start()
    {
        foreach (var part in rocketParts)
        {
            tags_pos.Add(part.tag, part.transform.localPosition);
        }
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 1000000))
            {
                if (tags_pos.ContainsKey(hit.collider.gameObject.tag))
                {
                    isTouchingPart = true;
                    selectedPart = hit.collider.gameObject;
                    for (int i = 0; i < Rocket.transform.childCount; i++)
                    {
                        if (hit.collider.gameObject != Rocket.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject)
                            Rocket.transform.GetChild(i).gameObject.SetActive(false);

                    }
                    parts_camera_pos.TryGetValue(selectedPart.tag, out Vector3 value);
                    selectedPart.transform.localPosition = value;
                }
            }
            else
            {
                isTouchingPart = false;
                for (int i = 0; i < Rocket.transform.childCount; i++)
                    Rocket.transform.GetChild(i).gameObject.SetActive(true);
                tags_pos.TryGetValue(selectedPart.tag, out Vector3 value);
                selectedPart.transform.localPosition = value;
            }

        }

    }
}