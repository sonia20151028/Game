using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text testComponent;
    [SerializeField] State startingState;

    State state;

    int[] oddNumbers = { 1, 3, 5, 7, 9 };
    string[] weeks = { "Mon", "Tus", "Thu", "Weds", "Fri", "Sat", "Sun" };


    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        testComponent.text = state.GetStateStory();
        Debug.Log(oddNumbers[3]);
        Debug.Log(weeks[4]);
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }

    private void ManageStates()
    {
        var nextStates = state.GetNextStates();
        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }

            /*       if(Input.GetKeyDown(KeyCode.Alpha1))
                   {
                       state = nextStates[0];
                   }
                   }
            /*       if(Input.GetKeyDown(KeyCode.Alpha1))
                   {
                       state = nextStates[0];
                   } else if(Input.GetKeyDown(KeyCode.Alpha2))
                   {
                       state = nextStates[1];
                   }
                   else if (Input.GetKeyDown(KeyCode.Alpha3))
                   {
                       state = nextStates[2];
                   } else
                   {
                       state = nextStates[3];
                   }*/
            testComponent.text = state.GetStateStory();
    }
}
