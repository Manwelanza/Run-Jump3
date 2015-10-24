using UnityEngine;
using System.Collections;

public class moverPlataformas : MonoBehaviour
{

    public float speed = 8f;
    public float limiteMovimiento = 56f;
    public float tiempoQuietas = 2f;

    private Vector3 posicionInicial;
    private bool ida = true;
    private bool playerUp = false;
    private float contador = 0f;

    // Use this for initialization
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        if (ida)
        {
            if (transform.position.z <= posicionInicial.z + limiteMovimiento)
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                if (playerUp) // No funciona
                {
                    //Vector3 move = new Vector3(0f, 0f, speed);
                    //move.Normalize();
                    //move = transform.TransformDirection(move);
                    //player.GetComponent<CharacterController>().Move(move * Time.deltaTime);
                    //player.transform.Translate(move * Time.deltaTime);
                }

            }
            else
            {
                if (contador < tiempoQuietas)
                    contador += Time.deltaTime;
                else
                {
                    contador = 0f;
                    ida = false;
                }
            }
        }
        else
        {
            if (transform.position.z >= posicionInicial.z)
            {
                transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                if (playerUp) // no funciona
                {
                    //Vector3 move = new Vector3(0f, 0f, -speed);
                    //move.Normalize();
                    //move = transform.TransformDirection(move);
                    //player.GetComponent<CharacterController>().Move(move * Time.deltaTime);
                    //player.transform.Translate(move * Time.deltaTime);

                }
            }
            else
            {
                if (contador < tiempoQuietas)
                    contador += Time.deltaTime;
                else
                {
                    contador = 0f;
                    ida = true;
                }
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hola");
        if (collision.collider.tag == "Player")
        {
           //playerUp = true;
        }
      
    }
}
