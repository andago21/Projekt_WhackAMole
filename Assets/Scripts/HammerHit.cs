using UnityEngine;

public class HammerHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kollision mit: " + collision.gameObject.name);

        MoleController mole = collision.gameObject.GetComponent<MoleController>();
        if (mole != null)
        {
            mole.OnHit();
            GameManager.Instance.AddScore();
            AudioManager.Instance.PlayHit();
        }
    }
}