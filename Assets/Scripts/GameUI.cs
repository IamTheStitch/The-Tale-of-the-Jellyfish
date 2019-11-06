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
    private bool monkey, dog, pheasant;
    // Start is called before the first frame update
    void Start()
    {
        //monkey = game.monkey;
       // dog = game.dog;
        //pheasant = game.pheasant;
    }

    // Update is called once per frame
    void Update()
    {
        if (monkey)
        {
            sr = Monkey.GetComponent<SpriteRenderer>();
            sr.enabled = true;
        }
        else
        {
            sr = Monkey.GetComponent<SpriteRenderer>();
            sr.enabled = false;
        }
        if (dog)
        {
            sr = Dog.GetComponent<SpriteRenderer>();
            sr.enabled = true;
        }
        else
        {
            sr = Dog.GetComponent<SpriteRenderer>();
            sr.enabled = false;
        }
        if (pheasant)
        {
            sr = Dog.GetComponent<SpriteRenderer>();
            sr.enabled = true;
        }
        else
        {
            sr = Pheasant.GetComponent<SpriteRenderer>();
            sr.enabled = false;
        }
    }
}
