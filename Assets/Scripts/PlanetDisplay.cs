using UnityEngine;
using TMPro;

public class PlanetDisplay : MonoBehaviour
{
    public TextMeshProUGUI display_name;
    public TextMeshProUGUI display_infos;
    public GameObject pointer;
    public GameObject flightButton;
    public Planet planet;
    // creat an emplty objet and add this script to it and add a planet to it
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        //use sprite rendrer in object 
        spriteRenderer = GetComponent<SpriteRenderer>();
        //set sprite to planet sprite
        spriteRenderer.sprite = planet.planet_sprite;
        if (planet.planet_name == PlanetManager.currentPlanet)
        {
            Vector3 currentPlanetPos = gameObject.transform.position;
            PlanetManager.traveledPlanetsPos.Add(currentPlanetPos);
            gameObject.tag = "currentPlanet";
        }
        else
        {
            gameObject.tag = "planet";
        }
    }
    private void OnMouseOver()
    {
        spriteRenderer.color = Color.yellow;
        string info = "Mass: " + planet.mass + " Mj" +
            "\r\nRadius: " + planet.radius + " Jupiter" +
            "\r\nPeriod: " + planet.period + " years" +
            "\r\nDistance: " + planet.distance + "TU";
        display_name.text = planet.planet_name;
        display_infos.text = info;

    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
    void Update()
    {
        if (planet.planet_name == PlanetManager.selectedPlanet)
        {
            pointer.GetComponent<SpriteRenderer>().color = Color.blue;
            pointer.SetActive(true);
        }
        else if (planet.planet_name == PlanetManager.currentPlanet)
        {
            pointer.GetComponent<SpriteRenderer>().color = Color.red;
            pointer.SetActive(true);
        }
        else
        {
            pointer.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (!PlanetManager.traveledPlanetsPos.Contains(gameObject.transform.position))
        {
            PlanetManager.selectedPlanet = planet.planet_name;
            PlanetManager.selectedDistance = planet.distance;
            flightButton.SetActive(true);
        }
    }
}
