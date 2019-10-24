using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    private float lastShot = 0f;
    public bool partToDisappear;
    public AudioClip shotClip;
    private AudioSource auS;
    public GameObject dis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        auS = GetComponent<AudioSource>();
        if(partToDisappear && Time.time > lastShot + fireRate)
        {
            dis.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && !GameObject.Find("Player").GetComponent<Controller>().mobile)
        {
            fire();
        }
    }
    public void fire()
    {
        if (Time.time > lastShot + fireRate)
        {
            if (auS != null && shotClip != null)
            {
                auS.PlayOneShot(shotClip);
            }
            if (transform.Find("BarrelEnd")) { 
                Instantiate(bullet, transform.Find("BarrelEnd").position, transform.rotation);
            }
            lastShot = Time.time;
            if (partToDisappear)
            {
                dis.SetActive(false);
            }
        }
    }
}
