using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController
{
    VisualTreeAsset ListEntryTemplate;
    VisualTreeAsset ListEntryTemplate2;
    // UI element references
    ListView SenderList;
    ListView MessageList;
    SMSmessage selectedSender;
    public void InitializeSenderList(VisualElement root, VisualTreeAsset listElementTemplate, VisualTreeAsset listElementTemplate2)
    {
        EnumerateAllCharacters();

        // Store a reference to the template for the list entries
        ListEntryTemplate = listElementTemplate;
        ListEntryTemplate2 = listElementTemplate2;

        // Store a reference to the character list element
        SenderList = root.Q<ListView>("sender-list");
        MessageList = root.Q<ListView>("message-list");

        FillSenderList();

        // Register to get a callback when an item is selected
        SenderList.onSelectionChange += OnSenderSelected;
    }

    List<SMSmessage> AllSenders;
    // List<string> AllMessages;
    void EnumerateAllCharacters()
    {
        AllSenders = new List<SMSmessage>();
        // GameVariables.rootObject.messages[0].SMS;
        // 
        AllSenders.AddRange(Resources.LoadAll<SMSmessage>("SMSs"));
    }
    void FillSenderList()
    {
        // Set up a make item function for a list entry
        SenderList.makeItem = () =>
        {
            // Instantiate the UXML template for the entry
            var newListEntry = ListEntryTemplate.Instantiate();

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
            (item.userData as ListEntryController).SetSenderData(AllSenders[index]);
        };

        // Set a fixed item height
        SenderList.fixedItemHeight = 45;

        // Set the actual item's source list/array
        SenderList.itemsSource = AllSenders;
    }

    void OnSenderSelected(IEnumerable<object> selectedItems)
    {
        // Get the currently selected item directly from the ListView
        selectedSender = SenderList.selectedItem as SMSmessage;

        // Handle none-selection (Escape to deselect everything)
        if (selectedSender == null)
        {
            return;
        }
        FillSMSList();
        // // Fill in character details

    }
    void FillSMSList()
    {
        int counter = 0;
        // Set up a make item function for a list entry
        MessageList.makeItem = () =>
        {

            // Instantiate the UXML template for the entry
            var newListEntry = ListEntryTemplate2.Instantiate();
            counter++;
            if (counter % 2 == 0)
            {
                newListEntry = ListEntryTemplate.Instantiate();
            }
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
        MessageList.bindItem = (item, index) =>
        {
            (item.userData as ListEntryController).SetMessageData(selectedSender.messages[index]);
        };

        // Set a fixed item height
        MessageList.fixedItemHeight = 45;

        // Set the actual item's source list/array
        MessageList.itemsSource = selectedSender.messages;
    }
}
