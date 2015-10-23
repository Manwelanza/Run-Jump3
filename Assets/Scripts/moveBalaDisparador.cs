using UnityEngine;
using System.Collections;

public class moveBalaDisparador : MonoBehaviour
{

    public float speed = 1f;
    public float limiteBalas = 75f;
    private float contador = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        contador += speed;
        if (contador >= limiteBalas)
        {
            Destroy(this.gameObject);
        }
    }

}
