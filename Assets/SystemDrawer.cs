using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SystemDrawer : MonoBehaviour
{
    public SubSystem system;

    public int ID;

    public RectTransform Bar;

    public TMP_Text[] texts;

    public GameObject Selector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       // system = Player.me.SubSystems[ID];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter(){
        Selector.SetActive(true);
    }
    void OnMouseExit(){
        Selector.SetActive(false);
    }
    void OnMouseDown(){

    }
}
