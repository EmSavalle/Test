using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;
    private float timeOfStart;
    public int timeBeforeDestroy;
    public float speed;
    public bool destroyOnImpact = true;
    public bool explode = false;
    public GameObject explo;
	// Use this for initialization
	void Start () {
        timeOfStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime*-1;
        if (timeOfStart + timeBeforeDestroy < Time.time)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        HealthScript hs = other.gameObject.GetComponent<HealthScript>();
        Debug.Log("Hit");
        if(other.tag != "Room") { 
            if (hs)
            {
                hs.hit(dmg);
                if (explode)
                {
                    Instantiate(explo, transform.position, transform.rotation);
                }
                if (destroyOnImpact)
                {
                    Destroy(gameObject);
                }
            }
            if(other.name != "BossRoom")
            {

                if (explode)
                {
                    Instantiate(explo, transform.position, transform.rotation);
                }
                if (destroyOnImpact)
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}
