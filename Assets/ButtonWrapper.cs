using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWrapper : MonoBehaviour {
    public Controller c;
    public bool mUp = false;
    public bool mDo = false;
    public bool mL = false;
    public bool mR = false;
    public bool lUp = false;
    public bool lDo = false;
    public bool lL = false;
    public bool lR = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (mUp)
        {
            MoveForward();
        }
        if (mDo)
        {
            MoveBackward();
        }
        if (mL)
        {
            MoveLeft();
        }
        if (mR)
        {
            MoveRight();
        }
        if (lUp)
        {
            LookUp();
        }
        if (lDo)
        {
            LookDown();
        }
        if (lR)
        {
            LookRight();
        }
        if (lL)
        {
            LookLeft();
        }
    }
    public void clickmUp()
    {
        Debug.Log("Test");
        mUp = !mUp;
    }
    public void clickmDo()
    {
        mDo = !mDo;
    }
    public void clickmL()
    {
        mL = !mL;
    }
    public void clickmR()
    {
        mR = !mR;
    }
    public void clicklUp()
    {
        lUp = !lUp;
    }
    public void clicklDo()
    {
        lDo = !lDo;
    }
    public void clicklL()
    {
        lL = !lL;
    }
    public void clicklR()
    {
        lR = !lR;
    }
    public void MoveForward()
    {
        c.MoveForward();
    }
    public void MoveBackward()
    {
        c.MoveBackward();
    }
    public void MoveLeft()
    {
        c.MoveLeft();
    }
    public void MoveRight()
    {
        c.MoveRight();
    }
    public void LookUp()
    {
        c.LookUp();
    }
    public void LookDown()
    {
        c.LookDown();
    }
    public void LookLeft()
    {
        c.LookLeft();
    }
    public void LookRight()
    {
        c.LookRight();
    }
    public void fire()
    {
        c.fire();
    }
}
