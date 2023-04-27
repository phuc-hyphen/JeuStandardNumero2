using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-100)]

public class Timer : MonoBehaviour
{
    // private float timeLeft;
    public TextMeshProUGUI timerText;
    public string filePath;

    void Awake()
    {
        if (GameVariables.JsonPath == "")
        {
            GameVariables.JsonPath = filePath;
        }
        // GameVariables.JsonPath = filePath;
        // Read the json from the file into a string
        string json = System.IO.File.ReadAllText(GameVariables.JsonPath);
        // Deserialize the JSON into a Data object
        GameVariables.rootObject = JsonUtility.FromJson<RootObject>(json);
    }

    // Update is called once per frame

    void Update()
    {
        if (TimeManager.timeLeft > 0)
        {
            timerText.text = "Time Left: " + GameFunctions.displayTimeForm((int)TimeManager.timeLeft);
            TimeManager.timeLeft -= Time.deltaTime;
        }
        else
        {
            timerText.text = "Time's Out!";
            SceneManager.LoadScene(4);
        }
        if(PlanetManager.currentPlanet == "Kepler-452b" && TimeManager.timeLeft != 0)
        {
            SceneManager.LoadScene(5);
        }

    }
}
