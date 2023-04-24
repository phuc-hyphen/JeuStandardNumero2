using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SMS", menuName = "SMS")]
public class SMSmessage : ScriptableObject
{
    public string sender;
    public List<string> messages = new List<string>();
}
