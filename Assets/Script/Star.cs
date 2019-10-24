using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    public int duration;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            other.GetComponent<Controller>().invincibleStart(duration);
        }
        Destroy(gameObject);
    }
}
