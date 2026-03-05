using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public MoleController[] moles;
    public float roundDuration = 30f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    private int score = 0;
    private float timer;
    private bool isRunning = false;

    void Awake() => Instance = this;

    void Update()
    {
        if (!isRunning) return;
        timer -= Time.deltaTime;
        if (timerText) timerText.text = "Zeit: " + Mathf.CeilToInt(timer);
        if (timer <= 0f) EndRound();
    }

    public void StartRound()
    {
        score = 0;
        timer = roundDuration;
        isRunning = true;
        if (gameOverPanel) gameOverPanel.SetActive(false);
        if (scoreText) scoreText.text = "Score: 0";
        foreach (var m in moles) m.SetActive(true);
        Debug.Log("Round Started");
    }

    public void AddScore()
    {
        score++;
        if (scoreText) scoreText.text = "Score: " + score;
    }

    void EndRound()
    {
        isRunning = false;
        foreach (var w in moles) w.SetActive(false);
        if (gameOverPanel) gameOverPanel.SetActive(true);
    }
}