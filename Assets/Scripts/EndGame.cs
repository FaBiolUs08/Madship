using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject continueButton;
    public GameObject menu;
    public GameObject navettaFinta;
    public static bool endTransition = false;
    // aggiusta la posizione della navetta e della camera in modo da "raddrizzarle" l'animazione di rientro.
    private void Update()
    {
        if(DeletionHandler.GameEnded)
        {
            if (!endTransition)
            {
                ButtonManager.shareCamera.transform.position = Vector3.MoveTowards(ButtonManager.shareCamera.transform.position, new Vector3(ButtonManager.shareCamera.transform.position.x, ButtonManager.shareCamera.transform.position.y, 4970.5f), 3);
                ButtonManager.shareNavetta.transform.position = Vector3.MoveTowards(ButtonManager.shareNavetta.transform.position, new Vector3(-2.019997f, ButtonManager.shareNavetta.transform.position.y, 4920.5f), 1);
                if (ButtonManager.shareNavetta.transform.position == new Vector3(-2.019997f, ButtonManager.shareNavetta.transform.position.y, 4920.5f) && ButtonManager.shareCamera.transform.position == new Vector3(ButtonManager.shareCamera.transform.position.x, ButtonManager.shareCamera.transform.position.y, 4970.5f))
                {
                    endTransition = true;
                    navettaFinta.transform.position = ButtonManager.shareNavetta.transform.position;
                    ButtonManager.shareNavetta.gameObject.SetActive(false);
                    navettaFinta.GetComponent<Animator>().SetTrigger("endTrigger");

                }
            }
             
        }

    }
    // controllo di arrivo al traguardo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("AF"))
        {
            menu.GetComponent<Animator>().SetTrigger("Paused");
            menu.GetComponentInChildren<TextMeshProUGUI>().text = "LEVEL COMPLETED";
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "CONTINUE";
            DeletionHandler.GameEnded = true;
            ButtonManager.gameSpeed = 0;
            

        }
    }

    //blocca il menù pausa mentre l'animazione di fine gioco è in corso
    void LockMenu()
    {
        if (endTransition)
        {
            menu.GetComponent<Animator>().enabled = false;
        }
    }
}
