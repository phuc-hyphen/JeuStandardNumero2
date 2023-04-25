using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Planet", menuName = "Planet", order = 0)]
public class Planet : ScriptableObject
{
    public string planet_name;
    public float mass;
    public float radius;
    public float period;
    public float distance;
    public Sprite planet_sprite;
    public List<string> events_journal = new List<string>();
    public List<string> events_radio = new List<string>();
    public float penality = 1f;
}

