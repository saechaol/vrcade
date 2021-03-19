using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void SceneMain() {
        SceneManager.LoadScene("MainScene");
    }

    public void SceneFoosball() {
        SceneManager.LoadScene("Foosball");
    }

    public void SceneAirHockey() {
        SceneManager.LoadScene("AirHockey");
    }
    public void SceneBilliards() {
        SceneManager.LoadScene("Billards");
    }

    public void ScenePingPong() {
        SceneManager.LoadScene("TableTennis");
    }

    public void SceneTennis() {
        SceneManager.LoadScene("Tennis");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
