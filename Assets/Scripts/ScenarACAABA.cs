﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenarACAABA : MonoBehaviour
{
    public Text scenarioText;


    public List<string> scenario = new List<string>();

    public int indice = 0;

    void Start()
    {
        scenario.Add("La porte s’ouvre devant vous et vous vous dépêchez d’y pénétrer juste à temps pour échapper à la vague de monstres armés qui vous courez dessus. Vous auriez peut-être mieux fait de ne pas quitter l’armurerie…");
        scenario.Add("La porte se referme derrière Sekip et vous réalisez que vous êtes dans la salle de contrôle.");
        scenario.Add("Deux aliens avec des cornes sur la tête se tourne vers vous et sans réfléchir vous tirer dessus avec le pistolet noir, le faisant se décomposer lentement.");
        scenario.Add("C’était officiel, vous adorez cette arme.");
        scenario.Add("“Et maintenant ?”");
        scenario.Add("La question d’Innoth est excellente, et vous vous demandez la même chose.");
        scenario.Add("“Je propose qu’on trouve un moyen de se débarrasser des aliens à l’extérieur pour commencer!”");
        scenario.Add("“Bonne idée!”");
        scenario.Add("Vous explorez alors le poste de pilotage et regardez les boutons en vous demandant à quoi ils servent.");
        scenario.Add("Contrairement à vous, Sekip semble parfaitement à sa place.Au moins est - il qualifié!");
        scenario.Add("Il passe un coup sur le fauteuil de pilote et s’y installe.Il appuie ensuite sur un bouton vert et des écrans de contrôle sortent sur tableau de contrôle, vous montrant l’extérieur de la pièce.");
        scenario.Add("Il appuie sur un autre bouton et un gaze vert se répand dans le couloir.Les aliens tombent alors les uns après les autres!");
        scenario.Add("“Sekip! Tu es un génie!”");
        scenario.Add("“Je sais”");
        scenario.Add("Vous sortez enfin de la pièce grâce à un plan sur une tablette obtenu par Sekip, vous vous rendez à la sortie.");
        scenario.Add("Vous remontez à bord de votre vaisseau et contactez le centre de contrôle pour les prévenir et leur demander de venir pour récupérer le vaisseau désormais vide de toute vie.");
        scenario.Add("Pour une première mission, c’est une belle réussite!");
        scenarioText.text = scenario[0];
        indice++;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (indice != scenario.Count)
            {
                scenarioText.text = scenario[indice];
                indice++;
            }
            else
                SceneManager.LoadScene("Fin13");
            Debug.Log("Clic.");
        }
    }
}