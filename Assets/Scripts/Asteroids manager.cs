using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Asteroidsmanager : MonoBehaviour
{
    public GameObject[] AsteroidsArray = new GameObject[13];
    [SerializeField] private GameObject sceneReference;
    public float spawnAsteroidInterval;
    float Timer;
    GameObject asteroide;
    // prende i 13 tipi di Asteroidi possibili e ad inizio gioco inizia a spawnarli seguendo l'intervallo fornito 
    void Start()
    {
        Timer = spawnAsteroidInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonManager.inizioGioco && !DeletionHandler.GameEnded) 
        {
                if (Timer <= 0 && ButtonManager.shareCamera.transform.position.z < 4800.5f)
                {
                    Vector3 position = new Vector3(Random.Range(-57f, 59f), 5.55f, sceneReference.transform.position.z + 100);
                    asteroide = Instantiate(AsteroidsArray[Random.Range(0, 12)], position, Quaternion.identity);
                    asteroide.transform.localScale = new Vector3(15, 15, 15);
                    asteroide.tag = "Asteroids";
                    asteroide.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                    Timer = spawnAsteroidInterval;
                    
                }
                Timer -= Time.deltaTime; 
        }
    }
}
