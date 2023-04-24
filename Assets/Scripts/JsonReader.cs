using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public string filePath;
    // Start is called before the first frame update
    void Start()
    {
        string json = System.IO.File.ReadAllText(filePath);

        // Deserialize the JSON into a WeaponData object
        GameVariables.rootObject = JsonUtility.FromJson<RootObject>(json);

        // Print out the values
        Debug.Log("RootObject.messages.Count: " + GameVariables.rootObject.messages.Count);
        Debug.Log("RootObject.messages[0].numero: " + GameVariables.rootObject.messages[0].numero);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
