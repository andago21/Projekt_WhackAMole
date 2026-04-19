using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        int hs = HighscoreManager.Instance.GetHighscore();
        tmp.text = "High Score: " + hs;
    }
}