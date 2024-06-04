using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class SceneLoader : MonoBehaviour
{
    string sceneName;
    ARTrackedImageManager trackedImageManager;
    [SerializeField] GameObject OpenButton;
    [SerializeField] GameObject DetectedLevelObj;
    [SerializeField] TextMeshProUGUI DetectedLevelText;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += SceneSelector;
    }

    public void SceneSelector(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.updated)
        {
            sceneName = trackedImage.referenceImage.name;
            OpenButton.SetActive(true);
            DetectedLevelObj.SetActive(true);
            DetectedLevelText.text = sceneName;
            Debug.Log(sceneName);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
