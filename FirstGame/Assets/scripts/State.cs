using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="State")]
public class State : ScriptableObject
{
    [TextArea(5,8)] [SerializeField] string textInfo;
    [SerializeField] State[] nextStates;
    public string GetStateStory()
    {
        return textInfo;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }
}
