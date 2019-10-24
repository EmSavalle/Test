using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    public GameObject weaponToGive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.name == "Player")
        {
            Transform wSlot = o.gameObject.transform.Find("WeaponSlot");
            GameObject weapon = Instantiate(weaponToGive, wSlot);
            Destroy(gameObject);
        }
    }
}
