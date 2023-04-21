using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScreen : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    // Start is called before the first frame update
    public void MoveScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void changePlanet()
    {

        PlanetManager.currentPlanet = PlanetManager.selectedPlanet;
        TimeManager.timeLeft -= PlanetManager.selectedDistance * 3f;
        SceneManager.LoadScene(1);
    }
    public void displayObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

}
