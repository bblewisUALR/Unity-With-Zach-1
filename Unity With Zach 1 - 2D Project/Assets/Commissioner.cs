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
        rTagLimit = 10;
        fTagLimit = 10;
        authority = 10;
        aRegen = 1;
    }
	
    public void CommissionerUpdate()
    {
            authority += aRegen;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
