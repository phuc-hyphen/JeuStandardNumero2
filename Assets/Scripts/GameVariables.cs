using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables
{
    // Start is called before the first frame update
    public static RootObject rootObject;
    public static int counterLine(string str)
    {
        return Mathf.CeilToInt(str.Length / 13f);
    }
}
