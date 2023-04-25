using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunctions
{
    // Start is called before the first frame update
    public static int counterLine(string str)
    {
        return Mathf.CeilToInt(str.Length / 13f);
    }
    public static string displayTimeForm(int time)
    {
        //display time in format dd:hh:mm:ss
        string timeString = "";
        if (time >= 86400)
        {
            timeString += Mathf.Floor(time / 86400).ToString("00") + ":";
            time = (int)(time % 86400);
        }
        if (time >= 3600)
        {
            timeString += Mathf.Floor(time / 3600).ToString("00") + ":";
            time = (int)(time % 3600);
        }
        if (time >= 60)
        {
            timeString += Mathf.Floor(time / 60).ToString("00") + ":";
            time = (int)(time % 60);
        }
        else
        {
            timeString += "00:";
        }
        // string days = Mathf.Floor(time / 86400).ToString("00");
        // string hours = Mathf.Floor(time / 3600).ToString("00");
        // string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        // return days + ":" + hours + ":" + minutes + ":" + seconds;
        return timeString + ":" + seconds;
    }
}
