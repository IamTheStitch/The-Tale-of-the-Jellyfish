using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeGame : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] State startingState;
    bool purpleCoat;
    bool silverGauntlet;
    bool featherHat;

    string[] narratives = {};

    State story;

    void Start()
    {
        story = startingState;
        storyText.text = story.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState(); 
    }

    private void ManageState()
    {
        State[] nextStates = story.GetNextStates();
        if (nextStates.Length < 2 && Input.GetKeyDown(KeyCode.Return))
        {
            story = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            story = nextStates[0];
            if (!purpleCoat)
            {
                purpleCoat = true;
                silverGauntlet = false;
                featherHat = false;
            }
                
        }
        else if (nextStates.Length == 2 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            story = nextStates[1];
            if (!silverGauntlet)
            {
                purpleCoat = false;
                silverGauntlet = true;
                featherHat = false;
            }
        }
        else if (nextStates.Length == 3 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            story = nextStates[2];
            if (!featherHat)
            {
                purpleCoat = false;
                silverGauntlet = false;
                featherHat = true;
            }
        }
        storyText.text = story.GetStateStory();
    }
}
