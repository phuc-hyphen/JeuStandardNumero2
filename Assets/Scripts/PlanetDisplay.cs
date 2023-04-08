using UnityEngine;
using TMPro;

public class PlanetDisplay : MonoBehaviour
{
    public TextMeshProUGUI display_name;
    public TextMeshProUGUI display_infos;

    public Planet planet;
    // creat an emplty objet and add this script to it and add a planet to it
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        //use sprite rendrer in object 
        spriteRenderer = GetComponent<SpriteRenderer>();
        //set sprite to planet sprite
        spriteRenderer.sprite = planet.planet_sprite;
        // print(planet.planet_name);
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
}
