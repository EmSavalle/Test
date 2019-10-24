using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public bool opening = false;
    public Vector3 initPos;
    public Vector3 loweredPos;
    public Vector3 pos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
		if (opening && transform.position.y > loweredPos.y) {
			transform.position += new Vector3 (0, -1 * Time.deltaTime);
		}
	}
	public void open(){
		opening = true;
		initPos = transform.position;
	}
	public void close(){
		opening = false;
		transform.position = initPos;
	}
}
