using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public int dmg;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called 
    public void OnTriggerEnter(Collider other)
    {
        HealthScript hs = other.gameObject.GetComponent<HealthScript>();
        Debug.Log("Hit");
        if (hs)
        {
            hs.hit(dmg);
        }

    }
}
