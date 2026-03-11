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
    [SerializeField] private float rightOffset = 0.5f;

    private Canvas panelCanvas;

    private void OnEnable()
    {
        secondaryAction.action.Enable();
    }

    private void OnDisable()
    {
        secondaryAction.action.Disable();
    }

    private void Start()
    {
        panelCanvas = panelObject.GetComponentInChildren<Canvas>(true);
    }

    private void Update()
    {
        if (secondaryAction.action.WasPressedThisFrame())
        {
            panelCanvas.enabled = !panelCanvas.enabled;
        }
        
        if (panelObject != null && panelCanvas.enabled)
        {
            UpdatePanelPosition();
        }
    }

    private void UpdatePanelPosition()
    {
        Vector3 forward = playerTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = playerTransform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 targetPos = playerTransform.position
                            + forward * distanceInFront
                            + right * rightOffset;

        targetPos.y = playerTransform.position.y + heightOffset;

        panelObject.transform.position = targetPos;

        Vector3 euler = playerTransform.eulerAngles;
        panelObject.transform.rotation = Quaternion.Euler(0f, euler.y, 0f);
    }
}