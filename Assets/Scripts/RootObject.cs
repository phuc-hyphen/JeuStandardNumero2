using System.Collections.Generic;

[System.Serializable]
public class Message
{
    public string numero;
    public Radio radio;
    public List<SMS> SMS;
}

[System.Serializable]
public class Radio
{
    public string info;
    public int penality;
}

[System.Serializable]
public class SMS
{
    public List<string> text;
    public string Inter;
    public int Penality;

    public string another_planet;
}

[System.Serializable]
public class RootObject
{
    public List<Message> messages;
}
