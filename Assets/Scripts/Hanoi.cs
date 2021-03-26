﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hanoi : MonoBehaviour
{
    private static int cp = 0;
    private static int CP_MAX = 5;
    private static bool flag = false;
    private static List<Stack<int>> tours = new List<Stack<int>>();
    private static Hanoi pointeurFil;
    private int indice; // indice des tours
    private int value; // valeurs du fil
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (!flag)
        {
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            tours.Add(new Stack<int>());
            flag = true;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (name == "pic1")
        {
            tours[0].Push(3);
            tours[0].Push(2);
            tours[0].Push(1);
        }
        if (name.StartsWith("fil")) // initialisation fil tour 1
        {
            indice = 0;
            switch (name)
            {
                case "fil1":
                    value = 1;
                    break;
                case "fil2":
                    value = 2;
                    break;
                case "fil3":
                    value = 3;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MoveTo(int indiceTour)
    {
        Debug.Log("l'anneau " + value + " sur la tour " + indice + " se déplace sur la tour " + indiceTour); // mouvement
        transform.Translate((indiceTour - indice) * Vector3.right * 6, Space.Self);
    }

    private void OnMouseDown()
    {
        if (name.StartsWith("fil"))
        {
            if (tours[indice].Peek() == value)
            {
                pointeurFil = this;
            }
        } else
        {
            if (pointeurFil != null)
            {
                int indiceTour;
                switch (name)
                {
                    case "pic1":
                        indiceTour = 0;
                        break;
                    case "pic2":
                        indiceTour = 1;
                        break;
                    case "pic3":
                        indiceTour = 2;
                        break;
                    default:
                        indiceTour = -1;
                        break;
                }
                if (indice != indiceTour && (tours[indiceTour].Count == 0 || tours[indiceTour].Peek() > value))
                {
                    tours[indiceTour].Push(value);
                    tours[indice].Pop();
                    pointeurFil.MoveTo(indiceTour);
                    indice = indiceTour;
                    cp++;
                    if (tours[2].Count == 3) // victoire
                    {
                        SceneManager.LoadScene("Corridor_AA");
                    }
                    if (CP_MAX == cp) // défaite
                    {
                        SceneManager.LoadScene("Hangar_AB");
                    }
                }
            }
        }
    }
}
