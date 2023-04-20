using UnityEngine;
using TMPro;
using System.Linq;

public class PlanetDisplay : MonoBehaviour
{

    public GameObject pointer;
    public Planet planet;
    // creat an emplty objet and add this script to it and add a planet to it
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        //use sprite rendrer in object 
        spriteRenderer = GetComponent<SpriteRenderer>();
        //set sprite to planet sprite
        spriteRenderer.sprite = planet.planet_sprite;
        if (planet.planet_name == TimeManager.currentPlanet)
        {
            Vector3 currentPlanetPos = gameObject.transform.position;
            TimeManager.planetsPos.Add(currentPlanetPos);
            gameObject.tag = "currentPlanet";
            pointer.SetActive(true);
        }
        else
        {
            gameObject.tag = "planet";
            pointer.SetActive(false);
        }
    }
     void Update()
    {
        // if (planet.planet_name == TimeManager.currentPlanet)
        // {
        //     Vector3 currentPlanetPos = gameObject.transform.position;
        //     TimeManager.planetsPos.Add(currentPlanetPos);
        //     gameObject.tag = "currentPlanet";
        //     pointer.SetActive(true);
        // }
        // else
        // {
        //     gameObject.tag = "planet";
        //     pointer.SetActive(false);
        // }
    }
    private void OnMouseOver()
    {
        spriteRenderer.color = Color.yellow;
        TimeManager.planetName = planet.planet_name;
        string info = "Mass: " + planet.mass + " Mj" +
            "\r\nRadius: " + planet.radius + " Jupiter" +
            "\r\nPeriod: " + planet.period + " years" +
            "\r\nDistance: " + planet.distance + " LY";
        TimeManager.planetDetails = info;
    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
    private void OnMouseDown()
    {
        TimeManager.selectedPlanet = planet.planet_name;
        TimeManager.FlightButton = true;
    }
}
