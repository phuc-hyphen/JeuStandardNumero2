using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void changePlanet()
    {

        TimeManager.currentPlanet = TimeManager.selectedPlanet;
        
        SceneManager.LoadScene(1);
    }

}
