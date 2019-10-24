using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestruction : MonoBehaviour {
    public int timeBeforeDestruct = 10;
    private float timeAtStart = 0f;
    public AudioClip expl;
    
	// Use this for initialization
	void Start () {
        AudioSource aS = GetComponent<AudioSource>();
        if(aS != null && expl != null)
        {
            aS.PlayOneShot(expl);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(timeAtStart == 0f)
        {

            timeAtStart = Time.time;
        }
		if(timeAtStart+timeBeforeDestruct < Time.time)
        {
            Debug.Log("Explo");
            Debug.Log(timeAtStart);
            Destroy(gameObject);
        }
	}
}
