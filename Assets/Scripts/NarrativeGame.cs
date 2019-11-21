using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NarrativeGame : MonoBehaviour
{
    [SerializeField] private Sprite dice1;
    [SerializeField] private Sprite dice2;
    [SerializeField] private Sprite dice3;
    [SerializeField] private Sprite dice4;
    [SerializeField] private Sprite dice5;
    [SerializeField] private Sprite dice6;

    [Header("Jellyfish Clothing Choice")]
    [SerializeField] private Sprite coat;
    [SerializeField] private Sprite gauntlet;
    [SerializeField] private Sprite hat;

    [Header("Story")]
    [SerializeField] Text storyText;
    [SerializeField] State startingState;

    [Header("Clothing")]
    public bool purpleCoat;
    public bool silverGauntlet;
    public bool featherHat;
    public bool usingMuscle;
    public bool usingCharm;
    public bool usingIntellect;

    [Header("Stats")]
    public int muscle;
    public int charm;
    public int intellect;
    private int agreeable;
    private int bold;

    private int decisions;

    [Header("Characters")]
    public bool monkey;
    public bool dog;
    public bool pheasant;

    [Header("Types of Stats")]
    public GameObject muscleStat;
    public GameObject intStat;
    public GameObject charmStat;
    private TextMeshProUGUI mStat, iStat, cStat;

    [Header("In-Game")]
    public GameObject Jellyfish;
    public GameObject Monkey;
    public GameObject Dog;
    public GameObject Pheasant;

    [Header("Dice")]
    public GameObject dice;
    public int diceRoll;
    public TextMeshProUGUI diceAmount;
    State story;

    void Start()
    {
        Jellyfish.SetActive(false);
        story = startingState;
        storyText.text = story.GetStateStory();
        muscle = 0;
        charm = 0;
        intellect = 0;
        decisions = 0;
        diceRoll = 1;
        diceAmount.text = diceRoll.ToString();
        mStat = muscleStat.GetComponent<TextMeshProUGUI>();
        iStat = intStat.GetComponent<TextMeshProUGUI>();
        cStat = charmStat.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
        CheckForActiveCharacters();
        UpdateStats();
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
                            }
                            else if (index == 1)
                            {
                                purpleCoat = false;
                                silverGauntlet = true;
                                muscle += 2;
                                featherHat = false;
                                decisions++;
                            }
                            else if (index == 2)
                            {
                                purpleCoat = false;
                                silverGauntlet = false;
                                featherHat = true;
                                charm += 2;
                                decisions++;
                            }
                            break;
                        case (1):
                            if (index == 0)
                            {
                                muscle++;
                                decisions++;
                            }
                            else if (index == 1)
                            {
                                charm++;
                                decisions++;
                            }
                            else if (index == 2)
                            {
                                intellect++;
                                decisions++;
                            }
                            break;
                        case (2):
                            if (index == 0)
                                agreeable++;
                            else if (index == 1)
                                bold++;
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
    private void CheckForActiveCharacters()
    {
        if(purpleCoat)
        {
            Jellyfish.GetComponent<SpriteRenderer>().sprite = coat;
            Jellyfish.SetActive(true);
        }
        if (silverGauntlet)
        {
            Jellyfish.GetComponent<SpriteRenderer>().sprite = gauntlet;
            Jellyfish.SetActive(true);
        }
        if (featherHat)
        {
            Jellyfish.GetComponent<SpriteRenderer>().sprite = hat;
            Jellyfish.SetActive(true);
        }
        if (monkey)
        {
            Monkey.SetActive(true);
        }
        else
        {
            Monkey.SetActive(false);
        }
        if (dog)
        {
            Dog.SetActive(true);
        }
        else
        {
            Dog.SetActive(false);
        }
        if (pheasant)
        {
            Pheasant.SetActive(true);
        }
        else
        {
            Pheasant.SetActive(false);
        }
    }
    private void UpdateStats()
    {
        mStat.text = muscle.ToString();
        iStat.text = intellect.ToString();
        cStat.text = charm.ToString();
    }
    public void RollDice()
    {
        if(!usingCharm || !usingIntellect || !usingMuscle)
            diceRoll = (int)Random.Range(1.0f, 7.0f);
        if (usingCharm)
        {
            dice.gameObject.SetActive(true);
            diceAmount.gameObject.SetActive(true);
            diceRoll = (int)Random.Range(1.0f, 7.0f + charm);
        }
            
        else if (usingIntellect)
        {
            dice.gameObject.SetActive(true);
            diceAmount.gameObject.SetActive(true);
            diceRoll = (int)Random.Range(1.0f, 7.0f) + intellect;
        }
            
        else if (silverGauntlet)
        {
            dice.gameObject.SetActive(true);
            diceAmount.gameObject.SetActive(true);
            diceRoll = (int)Random.Range(1.0f, 7.0f) + muscle;
        }           
        //implement DiceRollChangning Sprites
        switch(diceRoll)
        {
            case (1):
                dice.gameObject.GetComponent<Image>().sprite = dice1;
                break;
            case (2):
                dice.gameObject.GetComponent<Image>().sprite = dice2;
                break;
            case (3):
                dice.gameObject.GetComponent<Image>().sprite = dice3;
                break;
            case (4):
                dice.gameObject.GetComponent<Image>().sprite = dice4;
                break;
            case (5):
                dice.gameObject.GetComponent<Image>().sprite = dice5;
                break;
            case (6):
                dice.gameObject.GetComponent<Image>().sprite = dice6;
                break;
        }
        diceAmount.text = diceRoll.ToString();
    }
    private void MonkeyEncounter()
    {

    }
    private void DogEncounter()
    {

    }
    private void PheasantEncounter()
    {

    }
}
