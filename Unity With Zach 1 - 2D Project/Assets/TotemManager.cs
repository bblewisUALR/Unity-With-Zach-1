using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemManager : MonoBehaviour {

    [SerializeField]
    FoxPop Foxes;
    [SerializeField]
    RabbitPop Rabbits;

    double FoxTotemCount = 0;
    double RabbitTotemCount = 0;

    int FoxTotemWeight = 50 ;
    int RabbitTotemWeight = 100;

    List<GameObject> FoxTotems = new List<GameObject>();
    List<GameObject> RabbitTotems = new List<GameObject>();

    public void Draw()
    {
        while (RabbitTotemCount<Rabbits.rCount / RabbitTotemWeight && (RabbitTotemCount + 1)< Rabbits.rCount / RabbitTotemWeight)
        {   
            GameObject go = (GameObject)Instantiate(Resources.Load("rabbit"));
            go.transform.Translate((float) Random.Range((float)187.88, (float)191.23), (float)219.50, 0);
            RabbitTotems.Add(go);
            RabbitTotemCount++;
        }

        while (RabbitTotemCount > (Rabbits.rCount / RabbitTotemWeight) && (RabbitTotemCount - 1) > Rabbits.rCount / RabbitTotemWeight)
        {
            RabbitTotems[0].GetComponent<Totem>().GetEaten();
            RabbitTotems.RemoveAt(0);
            RabbitTotemCount--;
        }
        while (FoxTotemCount < Foxes.fCount / FoxTotemWeight && (FoxTotemCount + 1) < Foxes.fCount / FoxTotemWeight)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("fox"));
            go.transform.Translate((float)Random.Range((float)193.25, (float)196.27), (float)219.50, 0);
            FoxTotems.Add(go);
            FoxTotemCount++;
        }

        while (FoxTotemCount > Foxes.fCount / FoxTotemWeight && (FoxTotemCount - 1) > Foxes.fCount / FoxTotemWeight)
        {
            Destroy(FoxTotems[0]);
            FoxTotems.RemoveAt(0);
            FoxTotemCount--;
        }

    }//close Draw()

	// Use this for initialization
	void Start () {
        Draw();
	}
	
	// Update is called once per frame
	void Update () {


    }
}
