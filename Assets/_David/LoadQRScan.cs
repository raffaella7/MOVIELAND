using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadQRScan : MonoBehaviour
{
    public void LoadQRScanner()
    {
        SceneManager.LoadScene("ScanQR");
    }
}
