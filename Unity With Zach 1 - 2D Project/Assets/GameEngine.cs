using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {
    [SerializeField] FoxPop Foxes;
    [SerializeField] RabbitPop Rabbits;
    [SerializeField] HunterPop Hunters;
    [SerializeField] Commissioner Commissioner;
    [SerializeField] RandomEventGenerator RandomEventGen;
    [SerializeField] Text DayDisplay;
    [SerializeField] Text AuthorityDisplay;
    [SerializeField] Text rTagDisplay;
    [SerializeField] Text fTagDisplay;
    [SerializeField] Text EventDisplay;
    [SerializeField] Text RabbitPopLabel;
    [SerializeField] Text FoxPopLabel;
    int frameCounter = 0;//To BE DELETED SOON
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
        {
            EventDisplay.text = "Game Over! No more foxes.";
            return 2;
        }
        if (Rabbits.rCount <= 0)
        {
            EventDisplay.text = "Game Over! No more rabbits.";
            return 3;
        }
        if (Rabbits.rCount >= Rabbits.rEXCESSPOINT)
        {
            EventDisplay.text = "Game Over! Too many rabbits.";
            return 4;
        }
        return 0;
    }//close int checkGameOver()

    void Start () {
        //Called by Unity upon initialization
        //nothing happens
    }

    public void StartOver()
    {
        turnTracker = 0;

        EventDisplay.text = "";
        DayDisplay.text = turnTracker.ToString();

        Rabbits.rCount = 100;
        Rabbits.rBreedSpeed = 1.3;

        Foxes.fCount = 20;
        Foxes.fEffectiveness = 1;
        Foxes.fRabbitsEatenToGrow = 1;

        Commissioner.rTagLimit = 10;
        Commissioner.fTagLimit = 10;
        Commissioner.authority = 10;
        Commissioner.aRegen = 1;

        AuthorityDisplay.text = Commissioner.authority.ToString();
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
            - (Commissioner.rTagLimit * Hunters.rHunterEffectiveness)
            //(Hunters.rHunterCount * Hunters.rHunterEffectiveness)
            - (Foxes.fCount*Foxes.fEffectiveness);
        if (Rabbits.rCount < 0)
            Rabbits.rCount = 0;

        //Update Fox Variables
        Foxes.fCount = Foxes.fCount
            - (Commissioner.fTagLimit * Hunters.fHunterEffectiveness);
        Foxes.fCount = Foxes.fCount
            + (Foxes.fCount*Foxes.fEffectiveness / Foxes.fRabbitsEatenToGrow);
        if (Foxes.fCount < 0)
            Foxes.fCount = 0;

        //Reset "Health" Variables
        Foxes.fEffectiveness = .5;
        Rabbits.rBreedSpeed = 1.3;
        Hunters.fHunterEffectiveness = 1;
        Hunters.rHunterEffectiveness = 1;

    }// close void populationUpdate()


    public void NewTurn()
    {
        /*--------------------------------------------------------------------------------------
         void NewTurn() by Zach Bolt
         This function is called by button click.
         This function contains 3 function calls
            1.) PopulationUpdate()
            2.) RandomEventGen.RandomEvent();
            3.) Commissioner.CommissionerUpdate()
         --------------------------------------------------------------------------------------*/
        if (CheckGameOver() == 0)
        {
            turnTracker++;
            PopulationUpdate();
            RandomEventGen.RandomEvent();
            Commissioner.CommissionerUpdate();
        }
    }//close void NewTurn()

    public void FoxTagPlusFive()
    {
        if (Commissioner.authority > 0)
        {
            Commissioner.authority--;
            Commissioner.fTagLimit += 5;
        }
    }

    public void FoxTagMinusFive()
    {
        if (Commissioner.authority > 0 && Commissioner.fTagLimit > 0)
        {
            Commissioner.authority--;
            Commissioner.fTagLimit -= 5;
        }
    }

    public void RabbitTagPlusFive()
    {
        if (Commissioner.authority > 0)
        {
            Commissioner.authority--;
            Commissioner.rTagLimit += 5;
        }
    }

    public void RabbitTagMinusFive()
    {
        if (Commissioner.authority > 0 && Commissioner.rTagLimit > 0)
        {
            Commissioner.authority--;
            Commissioner.rTagLimit -= 5;
        }
    }
   
    void Update () {
        // Update is called once per frame
        RabbitPopLabel.text = "Rabbits=" + Rabbits.rCount.ToString();
        FoxPopLabel.text = "Foxes=" + Foxes.fCount.ToString(); 
        DayDisplay.text = turnTracker.ToString();
        AuthorityDisplay.text = Commissioner.authority.ToString();
        rTagDisplay.text = Commissioner.rTagLimit.ToString();
        fTagDisplay.text = Commissioner.fTagLimit.ToString();
	}//close void Update()

}//close GameEngine definition
