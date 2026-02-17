using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PanelShowInFrontOfButtonPressed : MonoBehaviour
{
    [Header("Input Action")] 
    [SerializeField] private InputActionReference secondaryAction;

    [Header("UI Panel")] 
    [SerializeField] private GameObject panelObject;

    [Header("Positioning of Main Camera (XR Origin)")] 
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distanceInFront = 1.5f;
    [SerializeField] private float heightOffset = 0.5f;

    private void OnEnable()
    {
        secondaryAction.action.Enable();
    }

    private void OnDisable()
    {
        secondaryAction.action.Disable();
    }

    private void Update()
    {
        if (secondaryAction.action.WasPressedThisFrame())
        {
            panelObject.SetActive(!panelObject.activeSelf);
        }
        
        if (panelObject.activeSelf)
        {
            UpdatePanelPosition();
        }
    }

    private void UpdatePanelPosition()
    {
        Vector3 forward = playerTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 targetPos = playerTransform.position + forward * distanceInFront;
        targetPos.y = playerTransform.position.y + heightOffset;

        panelObject.transform.position = targetPos;
        
        Vector3 lookDir = panelObject.transform.position - playerTransform.position;
        lookDir.y = 0f;

        if (lookDir.sqrMagnitude > 0.001f)
        {
            panelObject.transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
