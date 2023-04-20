using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    public static float timeLeft = 3 * 24 * 60f;
    public static string currentPlanet = "6 Lyncis b";
    public static string selectedPlanet = "";

    public static string planetName = "";
    public static string planetDetails = "";

    public static bool FlightButton = false;
    public static List<Vector3> planetsPos = new List<Vector3>();
    public static List<string> planetsName = new List<string>();

    public List<string> journals = new List<string>();
    public List<string> radios = new List<string>();

}
