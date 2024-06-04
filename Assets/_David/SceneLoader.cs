using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    ARTrackedImageManager trackedImageManager;
    [SerializeField] GameObject OpenButton;
    [SerializeField] TextMeshProUGUI OpenButtonText;

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
            OpenButtonText.text = "Open " + sceneName;
            Debug.Log(sceneName);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
