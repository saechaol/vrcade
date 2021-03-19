using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    public GameObject textBox;
    public OVRCameraRig cameraRig;
    private TextMeshProUGUI TextPro;
    // Start is called before the first frame update
    void Start()
    {
        TextPro = textBox.GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = cameraRig.transform.position + new Vector3(0, 0.25f, 0.5f);
        gameObject.transform.rotation = cameraRig.transform.rotation;
    }

    public void setText(string t)
    {
        TextPro.text = t;
    }
}
