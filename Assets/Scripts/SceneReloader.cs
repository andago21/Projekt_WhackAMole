using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public void ReloadScene()
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.name);
    }
}
