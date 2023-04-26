using System.Collections.Generic;

public class GameVariables
{
    // Start is called before the first frame update
    public static RootObject rootObject;

    public static int currentRootObject = 0;

    public static string JsonPath = "";

    public static Radio CurrentRadio = new Radio();


    public static List<SMS> ListSMS = new List<SMS>();
    
    // public static Dictionary<string, List<string>> InterMessage = new Dictionary<string, List<string>>();
}
