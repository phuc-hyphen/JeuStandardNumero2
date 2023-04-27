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
        DontDestroyOnLoad(this);
        //use sprite rendrer in object 
        spriteRenderer = GetComponent<SpriteRenderer>();
        //set sprite to planet sprite
        spriteRenderer.sprite = planet.planet_sprite;
        //set a message to the planet
        onRemoteStart();
    }

    public void onRemoteStart()
    {
        if (GameVariables.currentRootObject < GameVariables.rootObject.messages.Count)
        {
            planet.message = GameVariables.rootObject.messages[GameVariables.currentRootObject];

            foreach (SMS sms in planet.message.SMS)
                for (int i = 0; i < sms.text.Count; i++)
                {
                    string newstr = sms.text[i].Replace("{this.planet}", planet.planet_name);
                    sms.text[i] = newstr;
                }
            planet.message.radio.info = planet.message.radio.info.Replace("{this.planet}", planet.planet_name);
            planet.message.radio.info = planet.message.radio.info.Replace("\n", " ");

            GameVariables.PlanetMessage.Add((planet.planet_name, planet.message));
            Debug.Log(planet.planet_name);
        }
        GameVariables.currentRootObject = GameVariables.currentRootObject % GameVariables.rootObject.messages.Count;

        if (planet.planet_name == PlanetManager.currentPlanet)
        {
            Vector3 currentPlanetPos = gameObject.transform.position;
            PlanetManager.traveledPlanetsPos.Add(currentPlanetPos);
            gameObject.tag = "currentPlanet";
            // check if the planet has a message
            if (GameVariables.PlanetMessage.Any(x => x.planet == planet.planet_name))
            {
                GameVariables.newMessage = true;
                Debug.Log("planet has a message");
                GameVariables.CurrentRadio = GameVariables.PlanetMessage.Find(x => x.planet == planet.planet_name).msg.radio;
                var list = GameVariables.PlanetMessage.Find(x => x.planet == planet.planet_name).msg.SMS;
                GameVariables.ListSMS.AddRange(list);
            }
            Debug.Log(GameVariables.ListSMS.Count);
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
            "\r\nDistance: " + planet.distance + "TiU";
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
