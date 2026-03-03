using UnityEngine;
using UnityEngine.Events;

public class StartButtonGame : MonoBehaviour
{
    public UnityEvent OnPressed;
    [SerializeField] private GameObject buttonGameObjekt;
    
    private bool gameStarted = false;
    
  
    public void StartGame()
    {
        gameStarted = true;
        Debug.Log("Game Has Started");
        OnPressed?.Invoke();
    }
    
    void OnMouseDown()
    {
        StartGame();
    }
}