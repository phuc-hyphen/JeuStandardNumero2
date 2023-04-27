using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController
{
    VisualTreeAsset ListEntryTemplate;
    VisualTreeAsset ListEntryTemplate2;
    // UI element references
    ListView SenderList;
    ListView MessageList;
    string selectedSender;
    List<string> AllSenders;
    Dictionary<string, List<string>> DictSenders = new Dictionary<string, List<string>>();
    public void InitializeSenderList(VisualElement root, VisualTreeAsset listElementTemplate, VisualTreeAsset listElementTemplate2)
    {
        EnumerateAllCharacters();

        ListEntryTemplate = listElementTemplate;
        ListEntryTemplate2 = listElementTemplate2;

        SenderList = root.Q<ListView>("sender-list");
        MessageList = root.Q<ListView>("message-list");
        SenderList.Clear();
        MessageList.Clear();
        // FillSenderList();
        FillSenderList();

        // Register to get a callback when an item is selected
        SenderList.onSelectionChange += OnSenderSelected;
    }

    void EnumerateAllCharacters()
    {
        if (GameVariables.ListSMS == null)
            return;
        else
        {
            foreach (SMS sms in GameVariables.ListSMS)
            {
                if (sms.Inter != null)
                {
                    if (DictSenders.ContainsKey(sms.Inter))
                    {
                        DictSenders[sms.Inter].AddRange(sms.text);
                        Debug.Log(sms.Inter);
                    }
                    else
                    {
                        DictSenders.Add(sms.Inter, sms.text);
                    }

                }
            }
            AllSenders = new List<string>(DictSenders.Keys);
        }
    }
    void FillSenderList()
    {
        // Set up a make item function for a list entry
        SenderList.makeItem = () =>
        {
            // Instantiate the UXML template for the entry
            var newListEntry = ListEntryTemplate2.Instantiate();

            // Instantiate a controller for the data
            var newListEntryLogic = new ListEntryController();

            // Assign the controller script to the visual element
            newListEntry.userData = newListEntryLogic;

            // Initialize the controller script
            newListEntryLogic.SetVisualElement(newListEntry);

            // Return the root of the instantiated visual tree
            return newListEntry;
        };

        // Set up bind function for a specific list entry
        SenderList.bindItem = (item, index) =>
        {
            // (item.userData as ListEntryController).SetSenderData(DictSenders.Keys.ToList()[index]);
            (item.userData as ListEntryController).SetSenderData(AllSenders[index]);
            // item.style.height = 45 * GameFunctions.counterLine(AllSenders[index].Inter);
        };

        // Set a fixed item height
        SenderList.fixedItemHeight = 45;

        // Set the actual item's source list/array
        SenderList.itemsSource = AllSenders;
    }

    void OnSenderSelected(IEnumerable<object> selectedItems)
    {
        // Get the currently selected item directly from the ListView
        selectedSender = SenderList.selectedItem as string;

        // Handle none-selection (Escape to deselect everything)
        if (selectedSender == null)
        {
            return;
        }
        // MessageList.itemsSource = selectedSender.text;
        // Debug.Log("count : " + selectedSender.text.Count);
        // MessageList.Clear();
        // MessageList.fixedItemHeight = 45;

        FillSMSList();
        // // Fill in character details

    }
    void FillSMSList()
    {
        int counter = 0;
        MessageList.makeItem = () =>
        {
            Debug.Log("count : " + counter);
            var newListEntry = ListEntryTemplate2.Instantiate();
            counter++;
            if (counter % 2 == 0)
            {
                newListEntry = ListEntryTemplate.Instantiate();
            }
            var newListEntryLogic = new ListEntryController();

            newListEntry.userData = newListEntryLogic;

            newListEntryLogic.SetVisualElement(newListEntry);

            return newListEntry;
        };

        // Set up bind function for a specific list entry
        MessageList.bindItem = (item, index) =>
        {
            if (index < DictSenders[selectedSender].Count)
            {
                (item.userData as ListEntryController).SetMessageData(DictSenders[selectedSender][index]);
                item.style.height = 45 * GameFunctions.counterLine(DictSenders[selectedSender][index]);
            }
        };

        // Set a fixed item height
        // MessageList.fixedItemHeight = 45;

        // Set the actual item's source list/array
        MessageList.itemsSource = DictSenders[selectedSender];

    }
}
