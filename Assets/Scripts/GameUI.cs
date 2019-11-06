using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    NarrativeGame game;
    public Camera cameraUI;
    public GameObject Jellyfish;
    public GameObject Monkey;
    public GameObject Dog;
    public GameObject Pheasant;
    public GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        cameraUI.gameObject.tag<Camera>() = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
