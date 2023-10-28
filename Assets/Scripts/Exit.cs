using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Exit : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button quit;
    [SerializeField] private UnityEngine.UI.Button restart;
    public GameObject Menu;
    bool gameIsPaused = true;
    
    // gestione dei bottoni nell'interfaccia nell'interfaccia della pausa attivata col tasto tab
    // quit è quit,   rewind è il bottone restart

    void Start()
    {
        quit.onClick.AddListener(Quit);
        restart.onClick.AddListener(Rewind);
    }


    public void Quit()
    {
        Application.Quit();
    }
    public void Rewind()
    {
        if (SceneManager.GetActiveScene().name == "level_22" || DeletionHandler.GameEnded)
        {
            Time.timeScale = 1f;
            ButtonManager.inizioGioco = false;
            SceneManager.LoadScene("level_22");
        }
        else
        {
            Time.timeScale = 1f;
            ButtonManager.inizioGioco = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }




    void Update()
    {
        if(ButtonManager.inizioGioco && !DeletionHandler.GameEnded)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Menu.GetComponent<Animator>().SetTrigger("Paused");
                Menu.GetComponentInChildren<TextMeshProUGUI>().text = "MENU";
                if (gameIsPaused)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
                gameIsPaused = !gameIsPaused;

            }
        }
    }

    
}

