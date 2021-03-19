
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public enum GameState { INTRO, CALIBRATION, PLAY}
    public GameObject introElement;
    public GameObject calibrationElement;
    private GameState s;
    public Calibrator calibrator;

    void Start()
    {
        introElement.SetActive(true);
        calibrationElement.SetActive(false);
        s = GameState.INTRO;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchScene(string scene)
    {
        if (scene.Equals("calibration") && s.Equals(GameState.INTRO))
        {
            introElement.SetActive(false);
            calibrationElement.SetActive(true);
            calibrator.calibrate();
            s = GameState.CALIBRATION;
        }

        if (scene.Equals("play") && s.Equals(GameState.CALIBRATION))
        {
            Debug.Log("Manager Setting play mode..");
            introElement.SetActive(false);
            calibrationElement.SetActive(false);
            calibrator.endCalibration();
            s = GameState.PLAY;
        }

        if (scene.Equals("reset") && s.Equals(GameState.PLAY))
        {
            introElement.SetActive(true);
            calibrationElement.SetActive(false);
            s = GameState.INTRO;
        }
    }
}
