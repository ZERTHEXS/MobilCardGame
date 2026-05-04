using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;


public class GameManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Canvas canvas;
    public List<CardSciptableObject> cardSciptableObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
        System.Random r = new System.Random();
        int rInt = r.Next(0, 3);

        GameObject cardGO = Instantiate(cardPrefab);
        cardGO.transform.SetParent(canvas.transform);

        CardViewManager view = cardGO.GetComponent<CardViewManager>();
        view.Init(cardSciptableObject[rInt]);
        }
    }
    
}
