using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullett : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // controlla le collisioni  con gli asteroidi e gli effetti seguenti(esplosione, suono)
    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.name.Contains("asteroid"))
        {
            AudioSource esplosione = GameObject.Find("Audio Source (1)").GetComponent<AudioSource>();
            esplosione.clip = ButtonManager.shareClip;
            esplosione.Play();
            Instantiate(GameObject.Find("Particle System"), this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            
        }
        
    }
}
