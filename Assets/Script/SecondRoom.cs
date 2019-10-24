using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoom : MonoBehaviour {
	public GameObject foe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter(Collider o)
    {
        Debug.Log(o.gameObject.name);
        if (o.gameObject.name == "Player")
        {
            foe.GetComponent<FoeScript>().trigger();

        }
    }
    void OnTriggerExit(Collider o)
    {
        Debug.Log(o.gameObject.name);
        if (o.gameObject.name == "Player")
        {
            foe.GetComponent<FoeScript>().untrigger();

        }
    }
}
