using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject balaDisparador;
    public GameObject BulletHole;
    public GameObject Player;
    public float delayTimer = 0.5f;
    public float delayStart = 0f;

    private float contador = 0f;
    private float contadorStart = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (contadorStart > delayStart)
        {
            if (contador > delayTimer)
            {
                Instantiate(balaDisparador, transform.position, transform.rotation);
                GetComponent<AudioSource>().Play();
                RaycastHit hit;
                Ray ray = new Ray(transform.position, new Vector3(1.0f, 0, 0));
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.collider.gameObject != Player)
                        Instantiate(BulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }

                contador = 0f;
            }
            contador += Time.deltaTime;
        }
        else
            contadorStart += Time.deltaTime;
    }
}
