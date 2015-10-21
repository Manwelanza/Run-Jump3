using UnityEngine;
using System.Collections;

public class controlbulletHole : MonoBehaviour {

    public float delayTimer = 3f;

    private float contador = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        contador += Time.deltaTime;
        if (contador > delayTimer)
            this.gameObject.SetActive(false);
	}
}
