using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EHDamageableComponent : EHActorComponent
{
    #region damage events
    
    #endregion damage events
    public int MaxHelath = 100;
    public int CurrentHealth { get; private set; }
    
    public void TakeDamage(int DamageApplied)
    {
        
    }

    public bool ApplyHealth(int Health)
    {

        return false;
    }

    public void OnActorDied()
    {
        
    }
}
