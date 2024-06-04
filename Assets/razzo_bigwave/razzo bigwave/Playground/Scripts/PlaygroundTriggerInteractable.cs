using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class PlaygroundTriggerInteractable : PlaygroundTriggerInterface
{
    public Vector3 _defaultPosition;
    public Quaternion _defaultRotation;

    private Transform _parentGrabbable;

    public UnityEvent _onEnter = new UnityEvent();
    public UnityEvent _onExit = new UnityEvent();

    public bool _isGrabbed { get; set; }

    public int GetViewID()
    {
        return GetComponentInParent<PhotonView>().ViewID;
    }

    public void ChangeOwnership(UnityAction<bool> changeOwner)
    {
        if (!PhotonNetwork.IsConnected)
            return;

        var photonV = GetComponentInParent<PhotonView>();

        if (!photonV.IsMine)
        {
            photonV.TransferOwnership(PhotonNetwork.LocalPlayer);

        }

        changeOwner?.Invoke(!photonV.IsMine);
    }


    private void Start()
    {
        _parentGrabbable = GetComponentInParent<Grabbable>().transform;

        _defaultPosition = _parentGrabbable.position;
        _defaultRotation = _parentGrabbable.rotation;
    }

    public void SetIsGrabbed(bool value) => _isGrabbed = value;


    private void OnTriggerEnter(Collider other)
    {
        if (!_enable)
            return;

        if (other.TryGetComponent<PlaygroundTriggerInteractor>(out var interactor))
        {
            if (interactor._ID == this._ID)
            {
                _onEnter?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_enable)
            return;

        //if (other.TryGetComponent<PlaygroundTriggerInteractor>(out var interactor))
        //{
        //    if (interactor._ID == this._ID)
        //    {
        //        _onExit?.Invoke();
        //    }
        //}
    }

    public void _onEnable(bool value)
    {
        _enable = value;
    }

    public void OnDelayExitEvent()
    {
        Invoke(nameof(OnExitInvoke), 0.4f);
    }

    private void OnExitInvoke()
    {
        _onExit?.Invoke();
    }

    public void ReturnToDefaultPositionWithOwnerCheck()
    {
        ChangeOwnership((changeOwner) =>
        {
            if (changeOwner)
            {
                Invoke(nameof(ReturnToDefaultPosition), 0.5f);
            }
            else
            {
                ReturnToDefaultPosition();
            }
        });
    }

    public void ReturnToDefaultPosition()
    {
        _parentGrabbable.position = _defaultPosition;
        _parentGrabbable.rotation = _defaultRotation;
    }
}
