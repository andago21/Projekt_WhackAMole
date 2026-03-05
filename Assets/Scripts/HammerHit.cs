using UnityEngine;
using UnityEngine.Events;

public class HammerHit : MonoBehaviour
{
    public UnityEvent onHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mole"))
        {
            onHit.Invoke();
        }
    }
}