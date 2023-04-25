using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhoneController : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    VisualTreeAsset ListEntryTemplate;

    [SerializeField]
    VisualTreeAsset ListEntryTemplate2;
    public string filePath;
    void OnEnable()
    {
        string json = System.IO.File.ReadAllText(filePath);

        // Deserialize the JSON into a WeaponData object
        GameVariables.rootObject = JsonUtility.FromJson<RootObject>(json);

        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>();
        // Initialize the character list controller
        var listController = new ListController();
        listController.InitializeSenderList(uiDocument.rootVisualElement, ListEntryTemplate, ListEntryTemplate2);
    }

}
