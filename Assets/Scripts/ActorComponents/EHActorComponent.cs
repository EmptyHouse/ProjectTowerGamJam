using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHActorComponent : MonoBehaviour
{
    public EHActor OwningActor { get; private set; }

    #region monobehaviour functions
    protected virtual void Awake()
    {
        InitializeOwningActor();
    }
    
    #endregion monobehaviour functions

    protected virtual void InitializeOwningActor()
    {
        OwningActor = GetComponent<EHActor>();
    }
    
    #region Owning Actor Functions
    
    #endregion 
}
