using UnityEngine;
using System.IO;

[System.Serializable]
public class HighscoreData
{
    public int highscore;
}

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    private string savePath;
    private HighscoreData data = new HighscoreData();

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        savePath = Application.persistentDataPath + "/highscore.json";
        Load();
    }

    public void TrySave(int score)
    {
        if (score > data.highscore)
        {
            data.highscore = score;
            File.WriteAllText(savePath, JsonUtility.ToJson(data));
            Debug.Log("Neuer Highscore: " + score);
        }
    }

    public int GetHighscore() => data.highscore;

    void Load()
    {
        if (File.Exists(savePath))
            data = JsonUtility.FromJson<HighscoreData>(File.ReadAllText(savePath));
    }

    public void ResetHighscore()
    {
        data.highscore = 0;
        File.WriteAllText(savePath, JsonUtility.ToJson(data));
        Debug.Log("Highscore resettet!");

        FindObjectOfType<HighscoreDisplay>()?.UpdateDisplay();
    }
}