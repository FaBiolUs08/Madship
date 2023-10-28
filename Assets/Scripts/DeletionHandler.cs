using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DeletionHandler : MonoBehaviour
{
    public GameObject menu;
    public GameObject padre;
    public ParticleSystem particleSystem;
    public static bool GameEnded;
    // Controlla il possibile impatto dell'astronave con un asteroide e se succede attiva la schermata di sconfitta.
    void Start()
    {
        GameEnded = false;
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name.Contains("asteroid"))
        {
            Instantiate(particleSystem, this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
            menu.GetComponent<Animator>().SetTrigger("Paused");
            menu.GetComponentInChildren<TextMeshProUGUI>().text = "YOU LOST";
            GameEnded = true;
            EndGame.endTransition = true;
            ButtonManager.gameSpeed = 40;
            AudioSource esplosione = GameObject.Find("Audio Source (1)").GetComponent<AudioSource>();
            esplosione.clip = ButtonManager.shareClip;
            esplosione.Play();

        }
    }
}
