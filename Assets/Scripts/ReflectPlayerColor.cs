using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReflectPlayerColor : MonoBehaviour
{
    public GameObject p1Striker;
    public Material p1Material;
    public GameObject p2Striker;
    public Material p2Material;
    public GameObject puck;

    void ChangeMaterial(Material material)
    {
        // http://answers.unity.com/answers/126302/view.html
        Material[] MArr = new Material[puck.GetComponent<Renderer>().materials.Length];
        puck.GetComponent<Renderer>().materials.CopyTo(MArr, 0);
        MArr[0] = material;
        puck.GetComponent<Renderer>().materials = MArr;
    }
    void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject);
        if(collision.gameObject == p1Striker)
        {
            ChangeMaterial(p1Material);
            print("Hit Player 1 Striker");
        }else if (collision.gameObject == p2Striker)
        {
            ChangeMaterial(p2Material);
            print("Hit Player 2 Striker");
        }
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
