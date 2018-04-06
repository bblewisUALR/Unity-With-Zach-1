using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemManager : MonoBehaviour {

    [SerializeField]
    FoxPop Foxes;
    [SerializeField]
    RabbitPop Rabbits;

    int FoxTotemCount = 0;
    int RabbitTotemCount = 0;

    int FoxTotemWeight = 20;
    int RabbitTotemWeight = 200;

    List<Totem> FoxTotems = new List<Totem>();
    List<Totem> RabbitTotems = new List<Totem>();

    void Draw()
    {
        FoxTotemCount = Foxes.fCount / FoxTotemWeight;
        RabbitTotemCount = Rabbits.rCount / RabbitTotemWeight;

        while (FoxTotems.Count < FoxTotemCount)
        {
            var newFoxTotem = new Totem();
            newFoxTotem.mySpecies = Totem.Species.fox;
            newFoxTotem.Draw();
            FoxTotems.Add(newFoxTotem);

        }//close while fox <

        while (RabbitTotems.Count < RabbitTotemCount)
        {
            var newRabbitTotem = new Totem();
            newRabbitTotem.mySpecies = Totem.Species.rabbit;
            newRabbitTotem.Draw();
            RabbitTotems.Add(newRabbitTotem);

        }//close while rabbit <


    }//close Draw()

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
