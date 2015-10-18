using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {
    public float velocidad = 200f;
    public float fuerzaSalto = 5f;
    public float rotateSpeed = 3f;
    private CharacterController cControl;

    // Use this for initialization
    void Start () {
        cControl = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Vector3 direction = new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        //float movementSpeed = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        //transform.Rotate(direction);
        //cControl.SimpleMove(transform.forward * movementSpeed);

        moveCharacter();
        jump();
        cControl.SimpleMove(new Vector3(0, 0, 0)); //Para que continue aplicandose la gravedad
    }

    void moveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0)
        {
            cControl.Move(transform.right * velocidad * Time.deltaTime);
        }
        if (horizontal < 0)
        {
            cControl.Move(-transform.right  * velocidad * Time.deltaTime);
        }
        if (vertical > 0)
        {
            cControl.Move(transform.forward * velocidad * Time.deltaTime);
        }
        if (vertical < 0)
        {
            cControl.Move(-transform.forward * velocidad * Time.deltaTime);
        }
    }

    void jump()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            //cControl.SimpleMove(new Vector3(0,1,0) * fuerzaSalto * Time.deltaTime);
            cControl.Move(new Vector3(0, fuerzaSalto, 0));
            Debug.Log("si si");
        }
    }
}

