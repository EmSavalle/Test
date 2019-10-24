using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RR : MonoBehaviour {
    private float timeStart;
    private bool waiting = false;
    public float timeBeforeRR = 7.2f;
    public GameObject rr;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeStart+timeBeforeRR < Time.time && waiting )
        {
            rr.SetActive(true);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") { 
            GetComponent<AudioSource>().enabled = true;
            timeStart = Time.time;
            waiting = true;
        }
    }
}
