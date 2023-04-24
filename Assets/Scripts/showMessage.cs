using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showMessage : MonoBehaviour
{
    public List<string> messages = new List<string>();
    public TextMeshProUGUI text;
    public void ShowMessage()
    {
        foreach (string mess in messages)
        {
            text.text += mess + "\n";
        }
    }
}
