using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoOnce : MonoBehaviour
{
    public GameObject pannel; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlanetManager.currentPlanet);

        if (PlanetManager.currentPlanet == "6 Lyncis b")
        {
            Debug.Log("active");
            pannel.SetActive(true);
        } else
        {
            Debug.Log("disable");
            pannel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
