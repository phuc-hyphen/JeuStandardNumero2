using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager
{
    public static string currentPlanet = "6 Lyncis b";
    public static string selectedPlanet = "";
    public static float selectedDistance = 0;
    public static float selectedPenality = 0;
    public static List<Vector3> traveledPlanetsPos = new List<Vector3>();
    public List<string> journals = new List<string>();
    public List<string> radios = new List<string>();

    public List<string> phone = new List<string>();
}
