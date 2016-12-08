using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Handles when dice are rolling and calls requirementhandler when dice are finished rolling

[RequireComponent(typeof(RequirementHandler))]
public class DiceManager : MonoBehaviour {
   
    private RequirementHandler RequirementHandler;

    //check last 3 frames if value of any die has changed
    private List<Die> DiceList = new List<Die>();
    private CircularBuffer lastSums = new CircularBuffer(3);
    private GameState gameState = GameState.ROLLING;
    private enum GameState
    {
        ROLLING, STOPPED
    }

	// Use this for initialization
	void Start () {
        RequirementHandler = GetComponent<RequirementHandler>();
	}

    // Update is called once per frame
    void Update() {
        switch (gameState)
        {
            case GameState.ROLLING:
                {
                    bool rolling = false;

                    foreach (Die d in DiceList)
                    {
                        if (d.rolling)
                        {
                            rolling = true;
                            break;
                        }
                    }

                    if (!rolling)
                    {
                        int sum = 0;
                        foreach (Die d in DiceList)
                        {
                            sum += d.value;
                        }
                        lastSums.Push(sum);

                        if (lastSums.Valid())
                        {
                            gameState = GameState.STOPPED;
                            List<int> diceValues = new List<int>();
                            foreach (Die d in DiceList)
                            {
                                diceValues.Add(d.value);
                            }
                            RequirementHandler.CheckRequirements(diceValues);
                        }
                        
                    }
                }
                break;
        }
	}

    public void SetDice(List<GameObject> dice)
    {
        foreach(GameObject g in dice)
        {
            DiceList.Add(g.GetComponent<Die>());
        }

        gameState = GameState.ROLLING;
    }

    public void Reset()
    {
        DiceList.Clear();
    }
}
