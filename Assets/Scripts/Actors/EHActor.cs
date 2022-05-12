using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHActor : MonoBehaviour
{
    public Animator Anim { get; private set; }
    
    #region monobehaviour functions

    protected virtual void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    #endregion moonbehaviour functions
}
