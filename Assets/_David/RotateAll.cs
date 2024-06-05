using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class RotateAll : MonoBehaviour
{
    // Start is called before the first frame update
    RocketPartSelect rocketPartSelect;
    bool isSlowRotating = false;
    bool isStartRotating = false;
    bool isStartScaling = true;
    float StartScaleDelay = 3f;
    float StartRotationDelay = 15f;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject refCamera;
    [SerializeField] Animator animatorController;
    [SerializeField] GameObject raycastManager;

    void Awake()
    {
        rocketPartSelect = raycastManager.GetComponent<RocketPartSelect>();
    }
    void Start()
    {
        StartCoroutine(RotateAllParts());
        StartCoroutine(ScaleRocket());
        PlaySplitAnimation();
        rocket.transform.localScale = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //scale from 0 to 314 over 3s
        if (isStartScaling)
        {
            if (rocket.transform.localScale.x < 314)
                rocket.transform.localScale += 130 * Time.deltaTime * new Vector3(1, 1, 1);
        }
        //rotate 360 degrees over 15s
        if (isStartRotating)
        {
            refCamera.transform.Rotate(24 * Time.deltaTime * Vector3.up);

        }
        //rotate 360 degrees over 120s in loop
        if (isSlowRotating)
        {
            transform.Rotate(2.5f * Time.deltaTime * Vector3.up);

        }
    }
    IEnumerator ScaleRocket()
    {

        yield return new WaitForSeconds(StartScaleDelay);
        isStartScaling = false;
        StartCoroutine(StartRotation());

    }

    IEnumerator StartRotation()
    {
        isStartRotating = true;
        yield return new WaitForSeconds(StartRotationDelay);
        isStartRotating = false;
    }

    IEnumerator RotateAllParts()
    {
        yield return new WaitForSeconds(StartScaleDelay + StartRotationDelay);
        rocketPartSelect.enabled = true;
        isSlowRotating = true;
    }

    void PlaySplitAnimation()
    {
        animatorController.Play("Split");
    }




}
