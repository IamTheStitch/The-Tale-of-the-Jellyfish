using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private NarrativeGame game;
    public GameObject Jellyfish;
    public GameObject Monkey;
    public GameObject Dog;
    public GameObject Pheasant;
    public GameObject Inventory;
    private SpriteRenderer sr;
    public bool monkey, dog, pheasant;
    // Start is called before the first frame update
    void Start()
    {
        monkey = false;
        dog = false;
        pheasant = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        checkForActiveCharacters();
    }
    public bool setActive(bool character, int ID)
    {
        switch(ID)
        {
            case (1):
                monkey = character;
                break;
            case (2):
                dog = character;
                break;
            case (3):
                pheasant = character;
                break;
        }
        return false;
    }
    private void checkForActiveCharacters()
    {
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
}
