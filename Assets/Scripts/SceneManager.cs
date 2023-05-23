using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private InputAction pinchPosition;
    [SerializeField] private InputAction pinchRotation;

    public Vector3 pinchPos;
    public Quaternion pinchRot;

void Start()
    {
        pinchPosition.Enable();
        pinchRotation.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        pinchPos = pinchPosition.ReadValue<Vector3>();
        pinchRot = pinchRotation.ReadValue<Quaternion>();

    }
}
