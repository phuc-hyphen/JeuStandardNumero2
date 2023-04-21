using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    // private float timeLeft;
    public TextMeshProUGUI timerText;
    // Update is called once per frame
    void Update()
    {
        if (TimeManager.timeLeft > 0)
        {
            timerText.text = "Time Left: " + Mathf.Round(TimeManager.timeLeft);
            TimeManager.timeLeft -= Time.deltaTime;
        }
        else
        {
            timerText.text = "Time's Up!";
            SceneManager.LoadScene(3);
        }

    }
}
