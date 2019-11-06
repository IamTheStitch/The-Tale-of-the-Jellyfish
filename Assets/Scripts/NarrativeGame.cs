using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeGame : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] State startingState;
    //first decisions
    public bool purpleCoat, silverGauntlet, featherHat;
    //counting the stats
    public int muscle, charm, intellect;
    //decision counter
    public int decisions;
    //characters
    public bool monkey, dog, pheasant;

    State story;

    void Start()
    {
        story = startingState;
        storyText.text = story.GetStateStory();
        muscle = 0;
        charm = 0;
        intellect = 0;
        decisions = 0;
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
        else
        {
            for (int index = 0; index < nextStates.Length; index++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index))
                {
                    switch (decisions)
                    {
                        case (0):
                            if (index == 0)
                            {
                                purpleCoat = true;
                                intellect += 2;
                                silverGauntlet = false;
                                featherHat = false;
                                decisions++;
                                break;
                            }
                            else if (index == 1)
                            {
                                purpleCoat = false;
                                silverGauntlet = true;
                                muscle += 2;
                                featherHat = false;
                                decisions++;
                                break;
                            }
                            else if (index == 2)
                            {
                                purpleCoat = false;
                                silverGauntlet = false;
                                featherHat = true;
                                charm += 2;
                                decisions++;
                                break;
                            }
                            break;
                        case (1):
                            if (index == 0)
                            {
                                muscle++;
                                decisions++;
                                break;
                            }
                            else if (index == 1)
                            {
                                charm++;
                                decisions++;
                                break;
                            }
                            else if (index == 2)
                            {
                                intellect++;
                                decisions++;
                                break;
                            }
                            break;
                        case (2):
                            break;
                        case (3):
                            break;
                        case (4):
                            break;
                        case (5):
                            break;
                        case (6):
                            break;

                    }
                    story = nextStates[index];
                }
            }
            storyText.text = story.GetStateStory();
        }
    }
}
