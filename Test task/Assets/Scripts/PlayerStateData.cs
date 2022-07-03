using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateData : MonoBehaviour
{
    public bool _isStateFinished { get; protected set; }

    public abstract void StateRun();

    public void ResetState()
    {
        _isStateFinished = false;
    }

}
