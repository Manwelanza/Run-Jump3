using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuGame : MonoBehaviour {

    public Image imageResume;
    public Image imageExit;
    public UnitPlayer player;
    public Text textResume;
    public Text textExit;
    public Canvas menu;

    private bool active = false;
    private int selector = 0;
    private static int TOTAL_OPTIONS = 2;
    private Image[] images;
    private Outline[] texts;

	// Use this for initialization
	void Start ()
    {
	    imageResume = imageResume.GetComponent<Image>();
        imageExit = imageExit.GetComponent<Image>();
        player = player.GetComponent<UnitPlayer>();
        textResume = textResume.GetComponent<Text>();
        textExit = textExit.GetComponent<Text>();
        menu = menu.GetComponent<Canvas>();
        images = new Image[TOTAL_OPTIONS];
        texts = new Outline[TOTAL_OPTIONS];
        images[0] = imageResume;
        images[1] = imageExit;
        texts[0] = textResume.GetComponent<Outline>();
        texts[1] = textExit.GetComponent<Outline>();
        images[0].enabled = true;
        texts[0].enabled = true;
        for (int i = 0; i < TOTAL_OPTIONS; i++)
        {
            images[i].enabled = false;
            texts[i].enabled = false;
        }
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (!active))
        {
            active = true;
            menu.enabled = true;
            images[0].enabled = true;
            texts[0].enabled = true;
            player.pause();
        }

        else if ((Input.GetKeyDown(KeyCode.Escape)) && (active))
        {
            active = false;
            images[selector].enabled = false;
            texts[selector].enabled = false;
            selector = 0;
            menu.enabled = false;
            player.pause();
        }

        if (active)
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
            {
                if (selector == 0)
                {
                    active = false;
                    selector = 0;
                    menu.enabled = false;
                    player.pause();
                }

                else
                {
                    player.pause();
                    Application.LoadLevel("StartMenu");
                }
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || 
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                images[selector].enabled = false;
                texts[selector].enabled = false;
                if (selector < TOTAL_OPTIONS - 1)
                {
                    selector++;
                }

                else
                {
                    selector = 0;
                }
                images[selector].enabled = true;
                texts[selector].enabled = true;
            }

            else if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                images[selector].enabled = false;
                texts[selector].enabled = false;
                if (selector <= 0)
                {
                    selector = TOTAL_OPTIONS - 1;
                }

                else
                {
                    selector--;
                }
                images[selector].enabled = true;
                texts[selector].enabled = true;
            }
        }

    }
}
