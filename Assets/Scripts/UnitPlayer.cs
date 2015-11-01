using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{
	float cameraRotX = 0f;
	public float cameraPitchMax = 45f;
	public bool muestraRaton = false;
	public AudioClip sonidoPerder;
	public AudioClip sonidoEstrella;

	// Estrellas del marcador de puntuacion
	public GameObject estrellaOff1;
	public GameObject estrellaOff2;
	public GameObject estrellaOff3;
	public GameObject estrellaOn1;
	public GameObject estrellaOn2;
	public GameObject estrellaOn3;

    // Estrellas para coger del mapa
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    private int nEstrellas = 1;
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    private float temporizador = 0f;
    private bool ganar = false;
    private float timeScale;
    private float fixedDeltaTime;


    // Use this for initialization
    public override void Start ()
	{
		Cursor.visible = muestraRaton;
		base.Start ();
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
        timeScale = Time.timeScale;
        fixedDeltaTime = Time.fixedDeltaTime;
    }
	
	// Update is called once per frame
	public override void Update ()
	{
        if (!ganar)
        {
            // rotation

            //transform.Rotate (0f, Input.GetAxis ("Mouse X") * turnSpeed * Time.deltaTime, 0f);

            //cameraRotX -= Input.GetAxis ("Mouse Y");

            cameraRotX = Mathf.Clamp(cameraRotX, -cameraPitchMax, cameraPitchMax);

            Camera.main.transform.forward = transform.forward;
            Camera.main.transform.Rotate(cameraRotX, 0f, 0f);

            // movement

            move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            move.Normalize();

            move = transform.TransformDirection(move);

            if (Input.GetKey(KeyCode.Space) && control.isGrounded)
            {
                jump = true;
            }
            // Mostrar el raton cuando se pulsa escape, volver a ocultarlo al pulsar otra vez
            if (Input.GetKey(KeyCode.Escape))
            {
                if (!Cursor.visible)
                {
                    muestraRaton = true;
                    Cursor.visible = muestraRaton;
                }
                else
                {
                    muestraRaton = false;
                    Cursor.visible = muestraRaton;
                }
            }

            running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            base.Update();
            temporizador += Time.deltaTime;
        }

        else
        {
            // Paramos el tiempo
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
            // Pasamos a otro nivel despues de un tiempo o lo que queramos
            if (Input.GetKey(KeyCode.R))
                perder();
                
        }
        GameObject.Find("Timer").GetComponent<TextMesh>().text = temporizador.ToString("F2") + "s";
    }

	void OnDestroy(){
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Recolectable")
        {
			AudioSource.PlayClipAtPoint(sonidoEstrella, transform.position);
            collider.gameObject.SetActive(false);
			nEstrellas++;
			switch(nEstrellas) {
			case 1:
				estrellaOff1.SetActive(false);
				estrellaOn1.SetActive(true);
				break;
			case 2:
				estrellaOff2.SetActive(false);
				estrellaOn2.SetActive(true);
				break;
			case 3:
				estrellaOff3.SetActive(false);
				estrellaOn3.SetActive(true);
                ganar = true;
				break;
			}
			            
        }

        if (collider.tag == "BalaDisparador")
        {
            perder();
            Destroy(collider.gameObject);
        }

        if (collider.tag == "LimiteInferior" || collider.tag == "Pinchos")
        {
            perder();
        }


    }

    public void perder ()
    {

		AudioSource.PlayClipAtPoint (sonidoPerder, transform.position);
        // Poner aqui, alguna notificacion o algo como que se ha perdido
        estrellaOff1.SetActive(true);
        estrellaOn1.SetActive(false);
        estrellaOff2.SetActive(true);
        estrellaOn2.SetActive(false);
        estrellaOff3.SetActive(true);
        estrellaOn3.SetActive(false);
        estrella1.SetActive(true);
        estrella2.SetActive(true);
        estrella3.SetActive(true);
        nEstrellas = 0;
        ganar = false;
        temporizador = 0f;
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = fixedDeltaTime;
        respawn();
    }

    private void respawn ()
    {
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }

    public void OnGUI ()
    {
        if (ganar)
        {
            
            string texto = "<b><color=blue>Has ganado</color>\n<color=lightblue>Tiempo: " + temporizador.ToString("F2") + "s</color></b>";
            GUIStyle estilo = GUI.skin.GetStyle("Label");
            estilo.alignment = TextAnchor.UpperCenter;
            estilo.fontSize = 75;
            estilo.richText = true;
            GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 250, 800, 500), texto, estilo);
        }
    }
}
