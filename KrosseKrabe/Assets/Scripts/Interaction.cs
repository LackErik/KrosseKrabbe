using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 

public struct Interaction
{
    public GameObject model;
    public string instruction;
    public string helpMsg;
    public string errorMsg;
    public Transform endPosition;

}
