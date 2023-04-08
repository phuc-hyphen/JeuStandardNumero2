using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // private float timeLeft;
    public TextMeshProUGUI timerText;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     timeLeft = TimeManager.timeLeft;
    //     // DontDestroyOnLoad(this.gameObject);
    // }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.timeLeft > 0)
        {
            TimeManager.timeLeft -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Round(TimeManager.timeLeft);
        }
        else
        {
            timerText.text = "Time's Up!";
        }

    }
}
