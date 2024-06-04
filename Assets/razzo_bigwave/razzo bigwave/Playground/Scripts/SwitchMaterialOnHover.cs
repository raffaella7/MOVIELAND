using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Oculus.Interaction;

public class SwitchMaterialOnHover : MonoBehaviour
{
    public MeshRenderer m_MeshRenderer;

    public SelectorMaterialInfo m_SelectorMaterialInfo;

    private InteractableUnityEventWrapper mEventWrapper;

    private void Start()
    {
        mEventWrapper = GetComponent<InteractableUnityEventWrapper>();
        mEventWrapper.WhenHover.AddListener(() => HoverColor());
        mEventWrapper.WhenUnhover.AddListener(() => UnhoverColor());
    }

    private void HoverColor()
    {
        if (m_MeshRenderer != null)
        {
            for (int i = 0; i < m_MeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i].color = m_SelectorMaterialInfo._selectObject;
            }
        }
    }

    private void UnhoverColor()
    {
        if (m_MeshRenderer != null)
        {
            for (int i = 0; i < m_MeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i].color = m_SelectorMaterialInfo._unselectObject;
            }
        }
    }
}
