using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdRoom : MonoBehaviour {
    public GameObject[] foes;
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
            foreach(GameObject foe in foes) { 
                foe.GetComponent<FoeScript>().trigger();
            }

        }
    }
    void OnTriggerExit(Collider o)
    {
        Debug.Log(o.gameObject.name);
        if (o.gameObject.name == "Player")
        {
            foreach(GameObject foe in foes) {
                foe.GetComponent<FoeScript>().untrigger();
            }
        }
    }
}
