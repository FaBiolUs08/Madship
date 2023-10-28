using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    // Script the cancella gli asteroidi che escono dal campo visivo del player ergo escono dal basse dello schermo
    void Start()
    {
        
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    
   
}
