using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commissioner : MonoBehaviour {
    public double rTagLimit;
    public double fTagLimit;
    public int authority;
    public int aRegen;

    // Use this for initialization
    void Start () {
        rTagLimit = 50;
        fTagLimit = 50;
        authority = 5;
        aRegen = 2;
    }
	
    public void CommissionerUpdate()
    {
            authority += aRegen;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
