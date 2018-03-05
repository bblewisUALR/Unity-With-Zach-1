using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {
    // Use this for initialization
    [SerializeField] GameEngine engine;
    FoxPop Foxes;
    RabbitPop Rabbits;
    HunterPop Hunters;
    Commissioner Player;
    void Start () {
        Foxes = engine.GetComponent<FoxPop>();
        Rabbits = engine.GetComponent<RabbitPop>();
        Hunters = engine.GetComponent<HunterPop>();
        Player = engine.GetComponent<Commissioner>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    string RandomEvent()
    {
        int choice = (int)Random.Range(1,8);
        switch (choice)
        {
            case 1:
                Hunters.fHunterEfficiency += .3;
                Hunters.rHunterEffectiveness += .3
                return "Illegal Hunters";

            case 2:
                Rabbits.rBreedSpeed -= .5;
                return "Rabbit disease";

            case 3:
                Foxes.fEfficiency -= .5;
                return "Fox disease";

            case 4:
                if (Rabbits.rCount > 50000)
                {
                    Player.aRegen -= 1;
                    return "Farmers mad about rabbits";
                }
                else
                    return "No Event Triggered";

            case 5:
                Rabbits.rBreedSpeed += .5;
                return "Rabbits breeding like rabbits";

            case 6:
                Foxes.fEfficiency += .5;
                return "Foxes breeding like rabbits";

            case 7:
                if (Foxes.fCount > 10000)
                {
                    Hunters.fHunterCount -= 10;
                    return "Foxes attack hunters";
                }
                else
                    return "No Event Triggered";
            case 8:
                Player.aRegen += 1;
                return "Increasing Authority";
            default:
                return "No Event Triggered";
        }
    }
}
