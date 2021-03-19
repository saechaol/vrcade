using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateTableTilt : MonoBehaviour
{
    public float velocityThresh;
    public float collisionWaitTime;
    public float stillnessWaitTime;
    public float forceMult;
    public GameObject puck;
    public float lastCollision;
    public float lastStill;
    public float mytime;
    public float sinceLastCollition;
    public float sinceLastStill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        lastCollision = Time.time;
        lastStill = -1;
        print("Collision " + Time.time.ToString());
        print(puck.GetComponent<Rigidbody>().velocity);
    }
    void CheckLastStill()
    {
        //Handle Stillness tracking
        if (puck.GetComponent<Rigidbody>().velocity.sqrMagnitude < velocityThresh * velocityThresh)
        {
            if (lastStill == -1)
            {
                lastStill = Time.time;
            }

        }
        else if (lastStill != -1)
        {
            lastStill = -1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckLastStill();
        if(lastStill != -1)
        {
            if ((Time.time - lastStill > stillnessWaitTime) && (Time.time - lastCollision > collisionWaitTime))
            {
                Vector2 gust = Random.insideUnitCircle * forceMult;
                puck.GetComponent<Rigidbody>().AddForce(gust.x, 0, gust.y, ForceMode.Impulse);
                print("Applied gust of " + gust.ToString() + " at " + Time.time.ToString());
            }
        }
        mytime = Time.time;
        sinceLastCollition = mytime - lastCollision;
        sinceLastStill = mytime - lastStill;
    }
}
