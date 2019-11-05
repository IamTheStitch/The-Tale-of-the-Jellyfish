using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates a scriptable asset file called Story
[CreateAssetMenu(menuName  = "Story")]
public class State : ScriptableObject
{
    //Text Area expands the field of the text area (words,lines)
    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }
}
