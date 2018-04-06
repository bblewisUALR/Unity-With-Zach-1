using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventGenerator : MonoBehaviour {

    [SerializeField] Text EventDisplay;
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

    public void RandomEvent()
    {
        int choice = (int)Random.Range(1,8);
        switch (choice)
        {
            case 1:
                Hunters.fHunterEffectiveness += .25;
                Hunters.rHunterEffectiveness += .25;
                EventDisplay.text = "Illegal Hunters";
                break;

            case 2:
                Rabbits.rBreedSpeed -= .5;
                EventDisplay.text = "Rabbit disease";
                break;
            case 3:
                Foxes.fEffectiveness -= .5;
                EventDisplay.text = "Fox disease";
                break;
            case 4:
                if (Rabbits.rCount > 50000)
                {
                    Player.aRegen -= 1;
                    EventDisplay.text = "Farmers mad about rabbits";
                }
                else
                    EventDisplay.text = "No Event Triggered";
                break;

            case 5:
                Rabbits.rBreedSpeed += .5;
                EventDisplay.text = "Rabbits breeding like rabbits";
                break;
            case 6:
                Foxes.fEffectiveness += .5;
                EventDisplay.text = "Foxes breeding like rabbits";
                break;
            case 7:
                if (Foxes.fCount > 10000)
                {
                    Hunters.fHunterEffectiveness -= .5;
                    EventDisplay.text = "Foxes attempt a coup, hunters flee.";
                }
                else
                    EventDisplay.text = "Foxes resent the hunters. Tensions are high.";
                break;
            case 8:
                Player.aRegen += 1;
                EventDisplay.text = "Increasing Authority";
                break;
            default:
                EventDisplay.text = "No Event Triggered";
                break;
        }
    }
}
