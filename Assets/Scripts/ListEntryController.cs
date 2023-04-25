using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class ListEntryController
{
    Label NameLabel;
    GroupBox groupBox;

    public void SetVisualElement(VisualElement visualElement)
    {
        NameLabel = visualElement.Q<Label>("sender");
        groupBox = visualElement.Q<GroupBox>();
    }

    public void SetSenderData(string sender)
    {
        NameLabel.text = sender;
        // groupBox.style.height = 45 * GameVariables.counterLine(sender);
    }
    public void SetMessageData(string sms)
    {
        NameLabel.text = sms;
        // groupBox.style.height = 45 * GameVariables.counterLine(sms);
    }

}
