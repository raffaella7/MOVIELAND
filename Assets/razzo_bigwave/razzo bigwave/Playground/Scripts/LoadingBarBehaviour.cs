using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(AudioSource))]
public class LoadingBarBehaviour : MonoBehaviourPun
{
    private Image image;

    [Header("Audio")]
    public AudioClip _loadingAudio;

    private AudioSource _sourceAudio;


    public void StartLoadingPreview(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(LoadPreview(duration));

        if (!PhotonNetwork.IsConnected)
            return;

        photonView.RPC("StartLoadingPreviewSync", RpcTarget.Others, (float)duration);
    }

    [PunRPC]
    private void StartLoadingPreviewSync(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(LoadPreview(duration));
    }


    IEnumerator LoadPreview(float duration)
    {
        // audio start
        if (_sourceAudio == null)
        {
            _sourceAudio = GetComponent<AudioSource>();
            _sourceAudio.loop = true;
            _sourceAudio.spatialBlend = 1;
        }

        _sourceAudio.clip = _loadingAudio;
        _sourceAudio.Play();

        if (image == null)
            image = GetComponent<Image>();

        float timeStep = 0;

        while (timeStep <= duration)
        {
            timeStep += Time.deltaTime;
            float step = Mathf.Clamp01(timeStep / duration);
            float _previewValue = Mathf.Lerp(0, 1, step);

            image.fillAmount = _previewValue;
            yield return null;
        }

        image.fillAmount = 0;


        // audio end
        _sourceAudio.Stop();
    }
}
