using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PicoSecondaryButtonLogger : MonoBehaviour
{
    [SerializeField] private InputActionReference secondaryAction;

    private void OnEnable()
    {
        secondaryAction?.action.Enable();
    }
    
    private void OnDisable()
    {
        secondaryAction?.action.Disable();
    }

    private void Update()
    {
        if (secondaryAction == null)
        {
            Debug.Log("Secondary Action not set");
            return;
        }

        if (secondaryAction.action.WasPressedThisFrame())
        {
            Debug.Log("Secondary Button pressed");
        }
    }
}
