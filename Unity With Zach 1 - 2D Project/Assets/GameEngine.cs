using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {
    [SerializeField] FoxPop Foxes;
    [SerializeField] RabbitPop Rabbits;
    [SerializeField] HunterPop Hunters;
    [SerializeField] Commissioner Commissioner;
    int turnTracker = 0;


    int CheckGameOver() {
        /*----------------------------------------------------------------------------------------
        int checkGameOver() by Benjamin Lewis
        SUMMARY:  
        This function serves to determine wether or not the game has ended by game rules
            0.) This function returns 0 if the game is not over.
            1.) End condition: unexpected error--this case should not happen.
            2.) End condition: foxes are extinct
            3.) End condition: rabbits are extinct
            4.) End condition: excessive rabbits
        -----------------------------------------------------------------------------------------*/
        if (Foxes.fCount <= 0)
            return 2;
        if (Rabbits.rCount <= 0)
            return 3;
        if (Rabbits.rCount >= RabbitPop.rEXCESSPOINT)
            return 4;

        return 0;
    }//close int checkGameOver()

    void Start () {
        //Called by Unity upon initialization
        //nothing happens
    }

    void PopulationUpdate()
    {
        /*------------------------------------------------------------------------------------------------
         void PopulationUpdate() by Ben Lewis and Zach Bolt
         
        This funciton is called by void NewTurn(). Its function is to enact the algorithms for
        changing the internal values of the RabbitPop class and then FoxPop class. If the populations dip
        bellow zero, they are set to zero.
         ------------------------------------------------------------------------------------------------*/

        //Update Rabbit Variables
        Rabbits.rCount = Rabbits.rCount * Rabbits.rBreedSpeed;
        Rabbits.rCount = Rabbits.rCount
            - (Hunters.rHunterCount * Hunters.rHunterEffectiveness)
            - (Foxes.fCount*Foxes.fEfficiency);
        if (Rabbits.rCount < 0)
            Rabbits.rCount = 0;

        //Update Fox Variables
        Foxes.fCount = Foxes.fCount 
            - (Hunters.fHunterCount * Hunters.fHunterEfficiency)
            + (Foxes.fEfficiency / Foxes.fRabbitsEatenToGrow);
        if (Foxes.fCount < 0)
            Foxes.fCount = 0;

    }// close void populationUpdate()


    void NewTurn()
    {
        /*--------------------------------------------------------------------------------------
         void NewTurn() by Zach Bolt
         This function is called by void Update(), which is run every frame by Unity.
         This function contains 3 function calls
            1.) PopulationUpdate()
            2.) RandomEvent()
            3.) Commissioner.CommissionerUpdate()
         --------------------------------------------------------------------------------------*/

        PopulationUpdate();
        //RandomEvent();
        Commissioner.CommissionerUpdate();

    }//close void NewTurn()


    
    void Update () {
        // Update is called once per frame
        if (CheckGameOver() == 0)
        {
            if (turnTracker == 200)
            {

                NewTurn();
                turnTracker = 0;

                Debug.Log("Fox Population: ");
                Debug.Log(Foxes.fCount);

                Debug.Log("Rabbit Population: ");
                Debug.Log(Rabbits.rCount);

                Debug.Log("Authority: ");
                Debug.Log(Commissioner.authority);
            }//close if(turnTracker)
            else
                turnTracker++;
        }//close if(CheckGameOver)
        else
        {
            Debug.Log("GAME OVER. End Condition:");
            Debug.Log(CheckGameOver());

        }//close else(checkGameover)
	}//close void Update()

}//close GameEngine definition
