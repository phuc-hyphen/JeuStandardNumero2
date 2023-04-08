using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Planet", order = 0)]
public class Planet : ScriptableObject
{
    public string planet_name;
    public float mass;
    public float radius;
    public float period;
    public float distance;
    public Sprite planet_sprite;

}
