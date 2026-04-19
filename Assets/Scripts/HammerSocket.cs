using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HammerSocket : MonoBehaviour
{
    public GameObject hammer;
    public GameObject hammerGhost;
    public Vector3 socketRotation = new Vector3(0, 0, 0); 

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Rigidbody hammerRb;

    void Start()
    {
        grabInteractable = hammer.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        hammerRb = hammer.GetComponent<Rigidbody>();

        grabInteractable.selectEntered.AddListener(OnHammerPickedUp);
        grabInteractable.selectExited.AddListener(OnHammerDropped);

        hammerGhost.SetActive(false);
    }

    void OnHammerPickedUp(SelectEnterEventArgs args)
    {
        CancelInvoke(nameof(ReturnToSocket)); 

        hammerRb.isKinematic = false;
        hammerGhost.SetActive(true);
    }

    void OnHammerDropped(SelectExitEventArgs args)
    {
        hammerRb.isKinematic = false; 
        hammerRb.useGravity = true;
        Invoke(nameof(ReturnToSocket), 3f);
    }

    void ReturnToSocket()
    {
        if (!grabInteractable.isSelected)
        {
            hammerRb.linearVelocity = Vector3.zero;
            hammerRb.angularVelocity = Vector3.zero;
            hammerRb.isKinematic = true; 
            hammer.transform.position = transform.position;
            hammer.transform.rotation = Quaternion.Euler(socketRotation);
            hammerGhost.SetActive(false);
        }
    }
}