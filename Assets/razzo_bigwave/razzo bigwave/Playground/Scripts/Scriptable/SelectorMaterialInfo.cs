using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new SelectorInfo",menuName = "Bigrock/CreateSelectorInfo")]
public class SelectorMaterialInfo : ScriptableObject
{
    public Color _selectObject;
    public Color _unselectObject;
}
