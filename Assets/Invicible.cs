using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invicible : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.name != "Player")
        {
            HealthScript hs = other.GetComponent<HealthScript>();
            if (hs)
            {
                hs.hit(100);
            }
        }
    }
}
