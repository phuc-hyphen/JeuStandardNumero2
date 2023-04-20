using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapButton : MonoBehaviour
{
    public TextMeshProUGUI display_name;
    public GameObject flightButton;
    public TextMeshProUGUI display_infos;

    public GameObject PlantePanel;

    private GameObject _cameraMap;
    // Start is called before the first frame update
    void Start()
    {
        _cameraMap = GameObject.FindGameObjectWithTag("cameraMap");
        PlantePanel.SetActive(false);
        _cameraMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        display_name.text = TimeManager.planetName;
        display_infos.text = TimeManager.planetDetails;
        flightButton.SetActive(TimeManager.FlightButton);
    }

    public void OnDisplayMap()
    {
        PlantePanel.SetActive(!PlantePanel.activeSelf);
        _cameraMap.SetActive(!_cameraMap.activeSelf);
        // display_name.SetActive(true);
    }
}
