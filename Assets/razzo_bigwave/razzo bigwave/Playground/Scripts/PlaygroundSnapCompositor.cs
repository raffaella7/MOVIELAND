using Oculus.Interaction;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class PlaygroundSnapCompositor : MonoBehaviourPun
{
    #region private Fields

    private PhotonView _photonView;
    private PlaygroundTriggerInteractable _tempInteractable;
    private int _grabberIDExit;

    #endregion

    #region public Fields

    public int _valuePlayground;
    public List<PlaygroundTriggerInteractable> playgroundTriggerInteractors = new List<PlaygroundTriggerInteractable>();
    public List<GameObject> selectors = new List<GameObject>();
    public List<GameObject> interactables = new List<GameObject>();
    public UnityEvent<float> _onResetComposer = new UnityEvent<float>();

    [Header("Audio")]
    public AudioClip _enterTrigger;
    public AudioClip _exitTrigger;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlaygroundTriggerInteractable>(out var interactor))
        {
            _tempInteractable = interactor;
        }
    }

    


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlaygroundTriggerInteractable>(out var interactor))
        {
            if (playgroundTriggerInteractors.Contains(interactor))
            {
                if (interactor._isGrabbed)
                    TryRemoveComposer(interactor._ID);

                playgroundTriggerInteractors.Remove(interactor);

                if (_exitTrigger != null)
                    AudioSource.PlayClipAtPoint(_exitTrigger, transform.position);
            }
        }
    }


    public void TryAddComposer(int value)
    {
        if (value == _valuePlayground)
        {
            if (_tempInteractable == null)
                return;

            if (!playgroundTriggerInteractors.Contains(_tempInteractable))
            {
                playgroundTriggerInteractors.Add(_tempInteractable);

                if (_enterTrigger != null)
                    AudioSource.PlayClipAtPoint(_enterTrigger, transform.position);


                // sync

                if (PhotonNetwork.IsConnected)
                {
                    int tempPhotonView = _tempInteractable.GetViewID();
                    photonView.RPC(nameof(SetTempInteractableSync), RpcTarget.Others, (int)tempPhotonView);
                }

            }

            _valuePlayground++;
            Invoke(nameof(DelaySelector), 0.6f);
        }
    }

    [PunRPC]
    private void SetTempInteractableSync(int viewID)
    {
        var playgInteractables = FindObjectsOfType<PlaygroundTriggerInteractable>(true);

        for (int i = 0; i < playgInteractables.Length; i++)
        {
            if (playgInteractables[i].GetViewID() == viewID)
            {
                _tempInteractable = playgInteractables[i];
            }
        }

        if (!playgroundTriggerInteractors.Contains(_tempInteractable))
        {
            playgroundTriggerInteractors.Add(_tempInteractable);
        }

    }


    private void DelaySelector()
    {
        for (int i = 0; i < selectors.Count; i++)
        {
            if (i == _valuePlayground)
            {
                selectors[i].SetActive(true);
                interactables[i].SetActive(true);
            }
            else
            {
                selectors[i].SetActive(false);
                interactables[i].SetActive(false);
            }
        }

        if (!PhotonNetwork.IsConnected)
            return;

        if(_photonView == null)
            _photonView = GetComponent<PhotonView>();

        _photonView.RPC(nameof(DelaySelectorSync), RpcTarget.Others, (int)_valuePlayground);
    }


    [PunRPC]
    private void DelaySelectorSync(int valuePlaygroundSync)
    {
        _valuePlayground = valuePlaygroundSync;

        for (int i = 0; i < selectors.Count; i++)
        {
            if (i == _valuePlayground)
            {
                selectors[i].SetActive(true);
                interactables[i].SetActive(true);
            }
            else
            {
                selectors[i].SetActive(false);
                interactables[i].SetActive(false);
            }
        }
    }


    public void TryRemoveComposer(int value)
    {
        if (_valuePlayground >= value)
        {
            _grabberIDExit = value;

            for (int i = 0; i < playgroundTriggerInteractors.Count; i++)
            {   
                if (playgroundTriggerInteractors[i]._ID > value)
                {
                    playgroundTriggerInteractors[i].ReturnToDefaultPositionWithOwnerCheck();
                }
            }
        }

        Invoke(nameof(StepCheck), 1.0f);

        _onResetComposer?.Invoke(1.6f);
    }

    private void StepCheck()
    {       
        _valuePlayground = playgroundTriggerInteractors.Count;
        Invoke(nameof(DelaySelector), 0.6f);
    }
}
