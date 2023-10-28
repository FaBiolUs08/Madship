using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button btnLvl1;
    [SerializeField] private Button btnLvl22;
    [SerializeField] private Button btnQuit;
    [SerializeField] private GameObject padre;
    [SerializeField] private GameObject hudIniziale;
    [SerializeField] private GameObject camera;
    [SerializeField] public GameObject navetta;
    [SerializeField] public GameObject coolDownLight;
    [SerializeField] public AudioSource theme;
    [SerializeField] public AudioSource soundEffect;
    [SerializeField] public AudioClip Shoot;
    [SerializeField] public AudioClip explosion;
    public GameObject Bullet;
    Color giallo = new Vector4(255, 255, 0, 0.39f);
    Color bianco = new Vector4(255, 255, 255, 0.39f);
    Color rosso = new Vector4(255, 0, 0, 0.39f);
    Color verde = new Vector4(0, 255, 0, 0.39f);
    [SerializeField] public float cameraSpeed;
    public static float gameSpeed, timer = 0;
    public static  bool  inizioGioco;
    public static GameObject shareCamera;
    public static GameObject shareNavetta;
    public static AudioClip shareClip;
    float gunTimer;
    Vector3 movimentoCamera;
    

    // aggiunge i listener e riporta i valori delle variabili pubbliche a quelle statiche
    void Start()
    {
        gameSpeed = cameraSpeed;
        shareCamera = camera;
        shareNavetta = navetta;
        shareClip = explosion;
        this.btnQuit.onClick.AddListener(ListenerQuit);
        this.btnLvl1.onClick.AddListener(ListenerBegin);
        this.btnLvl22.onClick.AddListener(ListenerChangeScene);
        EndGame.endTransition = false;
        
    }

    // gestisce lo sparo della navetta e la colorazione dell'interfaccia 
    void Update()
    {
        
        if (inizioGioco)
        {
            movimentoCamera = new Vector3(0, gameSpeed * Time.deltaTime, 0);
            camera.GetComponent<Transform>().Translate(movimentoCamera);
            if (!EndGame.endTransition)
            {
                padre.GetComponent<Animator>().enabled = false;
                float xMove = Input.GetAxis("Horizontal") * gameSpeed * Time.deltaTime;
                float yMove = Input.GetAxis("Vertical") * gameSpeed * Time.deltaTime;


                if (timer > 0)
                {
                    coolDownLight.GetComponent<Image>().color = rosso;
                }
                else
                {
                    coolDownLight.GetComponent<Image>().color = verde;
                    if (Input.GetMouseButton(0))
                    {
                        soundEffect.clip = Shoot;
                        soundEffect.Play();
                        GameObject shotBullet = Instantiate(Bullet, new Vector3(navetta.transform.position.x, navetta.transform.position.y, navetta.transform.position.z), Quaternion.Euler(0, navetta.transform.localRotation.z, 0));
                        shotBullet.GetComponentInChildren<Rigidbody>().AddForce(shotBullet.transform.forward * 30000);
                        timer = 0.4f;
                    }
                }
                timer -= Time.deltaTime;
               
                if (SceneManager.GetActiveScene().name == "level_22")
                {
                    AsseVerticale(yMove);
                }
                else
                {
                    yMove = 0;
                }
                AsseOrizontale(xMove);
                navetta.GetComponent<Rigidbody>().velocity = new Vector3(30 * xMove, 0, 30 * yMove);
            }
        }
    }

    //gestisce l'illuminazione dell'interfaccia e l'inclinazione della navetta nell'asse orizzontale
    void AsseOrizontale(float xMove)
    {
        if (xMove != 0)
        {
            if (xMove > 0)
            {
                GameObject.Find("LeftArrow").GetComponent<Image>().color = bianco;
                GameObject.Find("RightArrow").GetComponent<Image>().color = giallo;
                navetta.GetComponent<Transform>().rotation = Quaternion.Euler(10, 20, 0);
            }
            else
            {
                GameObject.Find("LeftArrow").GetComponent<Image>().color = giallo;
                GameObject.Find("RightArrow").GetComponent<Image>().color = bianco;
                navetta.GetComponent<Transform>().rotation = Quaternion.Euler(-10, -20, 0);
            }
        }
        else
        {
            GameObject.Find("LeftArrow").GetComponent<Image>().color = bianco;
            GameObject.Find("RightArrow").GetComponent<Image>().color = bianco;
            navetta.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    //gestisce l'illuminazione dell'interfaccia sull'asse verticale (su / giu)
    void AsseVerticale(float yMove)
    {
        if (yMove != 0)
        {
            if (yMove > 0)
            {
                GameObject.Find("TopArrow").GetComponent<Image>().color = giallo;
                GameObject.Find("BottomArrow").GetComponent<Image>().color = bianco;
            }
            else
            {
                GameObject.Find("TopArrow").GetComponent<Image>().color = bianco;
                GameObject.Find("BottomArrow").GetComponent<Image>().color = giallo;
            }
        }
        else
        {
            GameObject.Find("TopArrow").GetComponent<Image>().color = bianco;
            GameObject.Find("BottomArrow").GetComponent<Image>().color = bianco;
        }
    }

    void ListenerQuit()
    {
        Application.Quit();
    }
    void ListenerChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "level_22")
        {
            padre.transform.GetComponent<Animator>().SetTrigger("Begin");
            padre.transform.GetComponent<Animator>().SetTrigger("FadeIn");
        }
        else
        {
            inizioGioco = false;
            SceneManager.LoadScene("level_22");
        }
    }

    void ListenerBegin()
    {
        if (SceneManager.GetActiveScene().name == "level_0")
        {
            padre.transform.GetComponent<Animator>().SetTrigger("Begin");
            padre.transform.GetComponent<Animator>().SetTrigger("FadeIn");
        }
        else
        {
            inizioGioco=false;
            SceneManager.LoadScene("level_0");
        }
    }

    void DisableMenu()
    {
        hudIniziale.SetActive(false);
    }

    public void EndAnimation()
    {
        inizioGioco = true;
        theme.Play();
    }


}
