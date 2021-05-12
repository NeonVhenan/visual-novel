﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memory : MonoBehaviour
{
    private enum CardID
    {
        SUN,
        ASTEROID,
        BANANA,
        SATELLITE,
        MOON,
        ALIENSHIP,
        CARDBACK, // face arriere
    }

    // game variables
    private static int ERRORS_MAX = 5;
    private static int errors = 0;
    private static bool flag = false;
    private static List<Memory> carteTirees = new List<Memory>();
    private static List<CardID> spritesName = new List<CardID>();
    // card variables
    public Sprite sun, asteroid, banana, satellite, moon, alien_ship_alt, card_back;
    public SpriteRenderer spriteRenderer;
    private bool isFacingCard = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!flag)
        {
            spritesName.Add(CardID.SUN);
            spritesName.Add(CardID.SUN);
            spritesName.Add(CardID.ASTEROID);
            spritesName.Add(CardID.ASTEROID);
            spritesName.Add(CardID.BANANA);
            spritesName.Add(CardID.BANANA);
            spritesName.Add(CardID.SATELLITE);
            spritesName.Add(CardID.SATELLITE);
            spritesName.Add(CardID.MOON);
            spritesName.Add(CardID.MOON);
            spritesName.Add(CardID.ALIENSHIP);
            spritesName.Add(CardID.ALIENSHIP);
            spritesName = spritesName.OrderBy(card => Guid.NewGuid()).ToList(); // aleatoire
            flag = true;
        }
    }

    /// <summary>
    ///  Appelé sur chaque gameobject avec le script ET boxcollider
    /// </summary>
    private void OnMouseDown() //This function is called each time player clicks on GameObject
    {
        if (!isFacingCard && CompareLastTwoCards())
        {
            isFacingCard = true;
            switch (name)
            {
                case "card1":
                    ChangeSide(spritesName[0]);
                    break;
                case "card2":
                    ChangeSide(spritesName[1]);
                    break;
                case "card3":
                    ChangeSide(spritesName[2]);
                    break;
                case "card4":
                    ChangeSide(spritesName[3]);
                    break;
                case "card5":
                    ChangeSide(spritesName[4]);
                    break;
                case "card6":
                    ChangeSide(spritesName[5]);
                    break;
                case "card7":
                    ChangeSide(spritesName[6]);
                    break;
                case "card8":
                    ChangeSide(spritesName[7]);
                    break;
                case "card9":
                    ChangeSide(spritesName[8]);
                    break;
                case "card10":
                    ChangeSide(spritesName[9]);
                    break;
                case "card11":
                    ChangeSide(spritesName[10]);
                    break;
                case "card12":
                    ChangeSide(spritesName[11]);
                    break;
            }
        }
    }

    private void ChangeSide(CardID cardID)
    {
        switch (cardID)
        {
            case CardID.SUN:
                spriteRenderer.sprite = sun;
                carteTirees.Add(this);
                break;
            case CardID.ASTEROID:
                spriteRenderer.sprite = asteroid;
                carteTirees.Add(this);
                break;
            case CardID.BANANA:
                spriteRenderer.sprite = banana;
                carteTirees.Add(this);
                break;
            case CardID.SATELLITE:
                spriteRenderer.sprite = satellite;
                carteTirees.Add(this);
                break;
            case CardID.MOON:
                spriteRenderer.sprite = moon;
                carteTirees.Add(this);
                break;
            case CardID.ALIENSHIP:
                spriteRenderer.sprite = alien_ship_alt;
                carteTirees.Add(this);
                break;
            case CardID.CARDBACK:
                spriteRenderer.sprite = card_back;
                break;
        }
        Debug.Log(carteTirees.Count);
        if (carteTirees.Count % 2 == 0 && carteTirees.Count != 0)
        { // vérification
            if (carteTirees[carteTirees.Count - 2].spriteRenderer.sprite.name == carteTirees[carteTirees.Count - 1].spriteRenderer.sprite.name)
            { // victoire
                if (carteTirees.Count == 12)
                {
                    Debug.Log("Victoire");
                    SceneManager.LoadScene("Corridor_AA");
                }
            }
            else
            {
                errors++;
                if (errors == ERRORS_MAX)
                { // défaite
                    Debug.Log("Défaite");
                    SceneManager.LoadScene("Hangar_AB");
                }
                StartCoroutine(Reset());
            }
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        carteTirees[carteTirees.Count - 2].spriteRenderer.sprite = card_back;
        carteTirees[carteTirees.Count - 2].isFacingCard = false;
        carteTirees[carteTirees.Count - 1].spriteRenderer.sprite = card_back;
        carteTirees[carteTirees.Count - 1].isFacingCard = false;
        carteTirees.RemoveAt(carteTirees.Count - 1);
        carteTirees.RemoveAt(carteTirees.Count - 1);
        yield return null;
    }

    /// <summary>
    /// Retourne vrai si les 2 dernieres cartes sont == ou si il n'y a pas 2 cartes.
    /// </summary>
    /// <returns></returns>
    private bool CompareLastTwoCards()
    {
        if (carteTirees.Count >= 2 && carteTirees.Count % 2 == 0)
        {
            return carteTirees[carteTirees.Count - 2].spriteRenderer.sprite.name == carteTirees[carteTirees.Count - 1].spriteRenderer.sprite.name;
        }
        else
        {
            return true;
        }
    }
}