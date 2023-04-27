using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PhoneController : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    VisualTreeAsset ListEntryTemplate;

    [SerializeField]
    VisualTreeAsset ListEntryTemplate2;
    [SerializeField]
    public UIDocument uiDocument;

    public void ReloadMessage()
    {
        GameVariables.newMessage = false;
        // The UXML is already instantiated by the UIDocument component
        // var uiDocument = GetComponent<UIDocument>();
        // Initialize the character list controller
        var listController = new ListController();
        listController.InitializeSenderList(uiDocument.rootVisualElement, ListEntryTemplate, ListEntryTemplate2);
    }
    // void Update() {
    //     if (GameVariables.newMessage)
    //     {
    //         var image =  GetComponent<Image>();
    //         image.color = Color.red;
    //     }
    // }
    // void OnEnable()
    // {
    //     // The UXML is already instantiated by the UIDocument component
    //     // var uiDocument = GetComponent<UIDocument>();
    //     // Initialize the character list controller
    //     var listController = new ListController();
    //     listController.InitializeSenderList(uiDocument.rootVisualElement, ListEntryTemplate, ListEntryTemplate2);
    // }
}
