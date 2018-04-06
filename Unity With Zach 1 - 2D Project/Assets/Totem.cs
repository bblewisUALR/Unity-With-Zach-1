using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour {

    public enum Species { fox, rabbit};

    public Species mySpecies;

    public void Draw()
    {
        switch (mySpecies)
        {
            case Species.fox:
                //load fox texture
                //instantiate a totem with fox texture
                //transform totem to (x,y)
                break;
            case Species.rabbit:
                //load rabbit texture
                //instantiate a totem with rabbit texture
                //transform totem to (x,y)
                break;
        }//close switch
    }



    // Use this for initialization
    void Start () {
    
	}//close start
	
	// Update is called once per frame
	void Update () {
		
	}
}
