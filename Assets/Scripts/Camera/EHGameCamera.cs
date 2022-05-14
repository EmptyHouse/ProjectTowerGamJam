using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHGameCamera : MonoBehaviour
{
    public Camera CameraComponent { get; private set; }

    private void Awake()
    {
        CameraComponent = GetComponentInChildren<Camera>();
    }
}
