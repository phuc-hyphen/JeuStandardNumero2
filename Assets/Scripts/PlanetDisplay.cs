using UnityEngine;
using TMPro;
using System.Linq;

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
        if (planet.planet_name == TimeManager.currentPlanet)
        {
            Vector3 currentPlanetPos = gameObject.transform.position;
            TimeManager.planets.Add(currentPlanetPos);
            gameObject.tag = "currentPlanet";
            pointer.SetActive(true);
        }
        else
        {
            gameObject.tag = "planet";
            pointer.SetActive(false);
        }
    }
    private void OnMouseOver()
    {
        spriteRenderer.color = Color.yellow;
        string info = "Mass: " + planet.mass + " Mj" +
            "\r\nRadius: " + planet.radius + " Jupiter" +
            "\r\nPeriod: " + planet.period + " years" +
            "\r\nDistance: " + planet.distance + " LY";
        display_name.text = planet.planet_name;
        display_infos.text = info;

    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
    private void OnMouseDown()
    {
        TimeManager.selectedPlanet = planet.planet_name;
        flightButton.SetActive(true);
    }
}
