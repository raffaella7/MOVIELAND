using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using static UnityEngine.Rendering.DebugUI;

public class RocketPartSelect : MonoBehaviour
{
    // Vector3[] newPositions;
    // [SerializeField] GameObject SplitRocket;
    bool canMoveOtherParts = true;
    bool canTouchScreen = true;
    public Camera mainCamera;
    [SerializeField] GameObject Rocket;
    bool isTouchingPart = false;
    GameObject selectedPart;
    public PartText selectedPartText;

    [SerializeField] public List<GameObject> rocketParts = new();
    public Dictionary<string, Vector3> tags_pos = new();
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

    List<Vector3> randPositions = new List<Vector3>() {
        new Vector3(-1.19500005f,2.99399996f,-0.00300000003f),
        new Vector3(1.11500001f,2.4059999f,-0.00300000003f),
        new Vector3(-1.16700006f,1.38499999f,-0.00300000003f),
        new Vector3(0.940999985f,0.462000012f,-0.00300000003f),
        new Vector3(-1.12800002f,-0.0340000018f,-0.00300000003f),
        new Vector3(-0.00800000038f,-1.79999995f,-0.00300000003f),
        new Vector3(1.18099999f,-0.999000013f,-0.00300000003f)
        };

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (canTouchScreen)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000000))
                {
                    if (tags_pos.ContainsKey(hit.collider.gameObject.tag))
                    {
                        isTouchingPart = true;
                        selectedPart = hit.collider.gameObject;
                        selectedPartText = selectedPart.GetComponent<PartText>();
                        // print(selectedPart);
                        if (canMoveOtherParts)
                        {
                            parts_camera_pos.TryGetValue(selectedPart.tag, out Vector3 value);
                            canTouchScreen = false;
                            StartCoroutine(MoveToPosition(selectedPart, value, .8f));
                            // selectedPart.transform.localPosition = value;
                            selectedPartText.Text.SetActive(true);
                            for (int i = 0; i < Rocket.transform.childCount; i++)
                            {
                                if (hit.collider.gameObject != Rocket.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject)
                                    // StartCoroutine(MoveToPosition(Rocket.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject, randPositions[Random.Range(0, randPositions.Count)], .5f));
                                    Rocket.transform.GetChild(i).gameObject.SetActive(false);

                            }
                        }
                        canMoveOtherParts = false;
                    }
                }
                else
                {
                    if (!canMoveOtherParts)
                    {
                        isTouchingPart = false;
                        tags_pos.TryGetValue(selectedPart.tag, out Vector3 value);
                        canTouchScreen = false;
                        StartCoroutine(MoveToPosition(selectedPart, value, .8f));
                        // selectedPart.transform.localPosition = value;
                        string fulltitletext = selectedPartText.Text.GetComponent<TypeWriterEffect>().fullText;
                        string fullsubtext = selectedPartText.Text.transform.GetChild(0).GetComponent<TypeWriterEffect>().fullText;
                        selectedPartText.Text.GetComponent<TextMeshProUGUI>().text = fulltitletext;
                        selectedPartText.Text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = fullsubtext;
                        selectedPartText.Text.SetActive(false);
                        for (int i = 0; i < Rocket.transform.childCount; i++)
                            Rocket.transform.GetChild(i).gameObject.SetActive(true);
                        // StartCoroutine(MoveToPosition(Rocket.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject, tags_pos[Rocket.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.tag], .5f));
                    }
                    canMoveOtherParts = true;
                }
            }
        }
    }

    IEnumerator MoveToPosition(GameObject objectToMove, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = objectToMove.transform.localPosition;

        while (time < duration)
        {
            float progress = SmoothProgress(time / duration);
            objectToMove.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, progress);
            time += Time.deltaTime;
            yield return null;
        }

        objectToMove.transform.localPosition = targetPosition;
        canTouchScreen = true;
    }

    public float SmoothProgress(float progress)
    {
        progress = Mathf.Lerp(-Mathf.PI / 2, Mathf.PI / 2, progress);
        progress = Mathf.Sin(progress);
        progress = (progress / 2) + 0.5f;
        return progress;
    }
}