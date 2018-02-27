using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
    [SerializeField] FoxPop Foxes;
    [SerializeField] RabbitPop Rabbits;
    [SerializeField] HunterPop Hunters;
    [SerializeField] Commissioner Commissioner;
    int turnTracker = 0;




    // Use this for initialization
    void Start () {
        Rabbits.rCount = 100;
        Rabbits.rBreedSpeed=1.3;
        Foxes.fCount = 20;
        Foxes.fEfficiency = 1;
        Foxes.fRabbitsEatenToGrow = 1;
        Hunters.rHunterCount = 10;
        Hunters.rHunterEffectiveness=1;
        Hunters.fHunterCount=10;
        Hunters.fHunterEfficiency=1;
        Commissioner.rLotterySize = 10;
        Commissioner.fLotterySize = 10;
    }

    void PopulationUpdate()
    {
        Rabbits.rCount = Rabbits.rCount * Rabbits.rBreedSpeed;

        Rabbits.rCount = Rabbits.rCount
            - (Hunters.rHunterCount * Hunters.rHunterEffectiveness * Commissioner.rLotterySize)
            - (Foxes.fCount*Foxes.fEfficiency);

        Foxes.fCount = Foxes.fCount - Hunters.fHunterCount * Hunters.fHunterEfficiency * Commissioner.fLotterySize;
        Foxes.fCount = Foxes.fCount * Foxes.fEfficiency / Foxes.fRabbitsEatenToGrow;
    }
    void NewTurn()
    {
        PopulationUpdate();
     //   RandomEvent();
        CommisionerUpdate();
    }
    void CommisionerUpdate()
    {
        Commissioner.authority += Commissioner.aRegen;
    }

    // Update is called once per frame
    void Update () {
        if (turnTracker==200)
        {
            NewTurn();
            turnTracker = 0;

            Debug.Log("Fox Population: ");
            Debug.Log(Foxes.fCount);

            Debug.Log("Rabbit Population: ");
            Debug.Log(Rabbits.rCount);

            Debug.Log("Authority: ");
            Debug.Log(Commissioner.authority);
        }
        else
        turnTracker++;
	}
}
