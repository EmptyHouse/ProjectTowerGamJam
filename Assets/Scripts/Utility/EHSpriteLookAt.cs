using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHSpriteLookAt : MonoBehaviour
{
    private EHGameCamera PlayerCamera;

    private void Awake()
    {
        PlayerCamera = Camera.main.GetComponentInParent<EHGameCamera>();
    }

    private void LateUpdate()
    {
        this.transform.LookAt(PlayerCamera.transform.position);
    }
}
