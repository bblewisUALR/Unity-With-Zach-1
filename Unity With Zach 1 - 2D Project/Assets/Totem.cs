using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour {

    public enum Species { fox, rabbit};
    [SerializeField] Sprite ChompedRabbit;
    [SerializeField] Sprite ShotFox;

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

    public void GetEaten()
    {
        if (mySpecies == Species.fox)
            GetComponent<SpriteRenderer>().sprite = ShotFox;
        else
            GetComponent<SpriteRenderer>().sprite = ChompedRabbit;
        StartCoroutine(PauseThenDelete());
    }

    IEnumerator PauseThenDelete()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
    
	}//close start
	
	// Update is called once per frame
	void Update () {
		
	}
}
