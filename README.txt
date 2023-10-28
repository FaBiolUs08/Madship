Autori: Fabio Porello

CONSEGNA DEL PROGETTO:
Realizzare un videogioco 3d  di tipo "arcade" per piattaforma Windows che chiameremo "MadShip".
Il gioco si svolgerà con scorrimento  verticale verso l'alto. 
La camera di gioco (proporzioni 10/16), puntata verso il basso,  seguirà un percorso lineare in avanti a velocità costante. La camera dovrà quindi inquadrare una porzione del livello di gioco e un'astronave "pilotata" dal giocatore (modello 3d fornito). 

La scena del gioco sarà composta da un parallelepipedo di sfondo texturizzato con immagine della Via Lattea (fornita) e da asteroidi (anch'essi forniti) che giacciono sullo stesso piano di volo dell'astronave. Il giocatore dovrà evitare l'impatto con gli asteroidi (o eventualmente distruggerli) per raggiungere il "traguardo".
Il traguardo sarà rappresentato da un oggetto collider che rileverà la collisione con l'astronave e determinerà il completamento del livello. 
Se l'astronave viene distrutta dalla collisione di un asteroide prima di raggiungere il traguardo, il giocatore ricomincia automaticamente il livello da capo. Il tempo di completamento del livello deve aggirarsi attorno al minuto. Pertanto l'oggetto traguardo dovrà essere opportunamente posizionato alla giusta distanza dal punto di partenza in relazione alla velocità di spostamento della camera (che dovrà essere deciso arbitrariamente).
L'astronave dovrà essere imparentata alla camera e mossa con la fisica all'interno dell'inquadratura (frustum). Dovranno quindi essere predisposti degli oggetti colliders per contenere l'astronave all'interno dell'inquadratura. L'astronave, così come altri oggetti del gioco, dovrà "scorrere" su un ipotetico piano xz quindi si dovrà impedire i movimenti sull'asse y e le eventuali rotazioni.Il giocatore potrà traslare l'astronave sul proprio asse orizzontale (x) utilizzando i tasti freccia destra/sinistra.


Inoltre il gioco dovrà soddisfare i seguenti punti:

Definire la variabile "cameraSpeed" per determinare la velocità di scorrimento del gioco;
Definire un array di gameobjects "asteroidi" (prefab) nominandolo: "asteroidsArray";
Gli asteroidi dovranno essere posizionati in modo randomico al di fuori dell'inquadratura (in alto) in attesa di entrare nell'inquadratura e essere raggiunti dall'astronave. 
Al momento dell'istanziazione, l'asteroide deve essere scalato della misura voluta, e messo in lenta rotazione sul posto (applicando una forza di tipo torque:
GetComponent<Rigidbody>().AddTorque(x,y,z).
Definire un parametro di intervallo di tempo che determina il posizionamento di un nuovo asteroide (es: ogni secondo viene "spawnato" un nuovo asteroide e posizionato in modo casuale). La variabile deve chiamarsi: "spawnAsteroidInterval".
Quando e` ora di posizionare un nuovo asteroide, "pescare" randomicamente il gameobject dall'array predisposto. Generare quindi un numero random tra due valori compresi. Es: Random.Range(1 , 100);
Nel caso di un indice dell'array:
Random.Range(0 , asteroidsArray.Lenght-1)
L'astronave deve poter sparare un proiettile alla pressione del tasto "fire1" (sistema input di Unity). 
Tra un proiettile e l'altro deve passare un intervallo di tempo determinato (es: 0.3 sec);
Il proiettile dovrà essere un prefab (capsula) istanziato al momento dello sparo nella opportuna posizione (appena davanti alla navicella). Appena istanziato, il proiettile dovrà essere spinto in avanti con una forza fisica (quindi il proiettile deve avere il component rigidbody).
Rilevare la collisione del proiettile con l'asteroide per distruggere entrambi i gameobjects: 
Object.Destroy(this.gameobject);
Creare quindi uno script apposta di "autodistruzione" quando viene rilevata la collisione (sia per il proiettile che per l'asteroide).
Predisporre due oggetti collider atti a distruggere tutti i proiettili che escono dall'inquadratura in alto e tutti gli asteroidi che escono dall'inquadratura in basso.
I due oggetti colliders dovranno quindi essere posizionati fuori dal frustum della camera (prima e dopo).
Al completamento del livello, aprire un interfaccia utente con il testo
"LEVEL COMPLETED", un tasto  "NEXT" e un tasto "QUIT".
Premendo il tasto quit si esce dal gioco. Premendo il tasto next si carica il livello successivo (nuova scena)
Realizzare un secondo livello in cui inserire un elemento aggiuntivo di difficolta`, e/o un elemento aggiuntivo  di "power up" a vostra discrezione.
Esempio di elemento aggiuntivo di difficolta`: posizionare lungo il percorso "rottami pazzi" che magari si muovono in modo imprevisto (animator?). 
Esempio di elemento di powerUp: posizionare lungo il percorso un oggetto "arma aggiuntiva" che, se catturata dalla nave, fornisce un cannone aggiuntivo per cui da quel momento in poi la nave sparerà due proiettili alla volta (paralleli).
Aggiungere un suono al lancio del proiettile e alle distruzioni di asteroidi e navicella.
Sono fornite due librerie di suoni da cui attingere oppure utilizzare un altri file audio di vostra provenienza;
 (facoltativo) Aggiungere suoni all'interfaccia;
(facoltativo) Prevedere la possibilità di completare il livello in maniera "perfect" cioè con il massimo risultato possibile: distruzione di tutti gli asteroidi generati, cattura di tutti i powerUp, ecc... . Rendere esplicito il "perfect" nell'interfaccia di fine livello.
(facoltativo) è possibile effettuare aggiunte migliorative  senza però "snaturare" il carattere del gioco.
Nominare il progetto Unity seguendo la forma:
MadShip_numeroregistro_COGNOME_NOME.
Es: MadShip_18_PORETTI_GIULIANO
Nominare le due scene (per i due livelli di gioco):
level_0
level_numeroregistro
Completato il level_0, se il giocatore preme il pulsante NEXT, dovrà caricarsi il level_numeroregistro (es: level_18)
Generare la build, completa dei due livelli, nella cartella BUILD (da creare all'interno del progetto)

