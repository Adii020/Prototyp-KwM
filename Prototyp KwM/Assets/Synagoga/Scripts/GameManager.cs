using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public Hud hud;
    //use to Replace shatted window
    public Transform replacement;
    //Bomb effect 
    public Transform bombParticlefield;
    //Window to destroy
    public GameObject[] windowsInteraction = new GameObject[3];
    public short levelNumber = 0;
    //Puzzle
    public GameObject puzzle;
    public PlayerControler playerControler;
    public PuzzleManager puzzleManager;

    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = this.gameObject.GetComponent<PuzzleManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (puzzle.GetComponent<Canvas>().enabled == false)
        {
            playerControler.cameraPlayer.GetComponent<MouseLookScript>().enabled = true;
        }
        else
        {
            hud.MousePosition();
        }

       
    
    }

    //Level 1 - destroy window play bomb sound and the player must collect the pieces window
    public void Level1()
    {
        bombParticlefield.GetComponent<AudioSource>().Play();
        bombParticlefield.GetComponent<ParticleSystem>().Play();
        Invoke("DestroyWindow", 4f);    
        hud.SetCollectionCount(0, 21);
        hud.Invoke("ShowCollecionInterface", 6f);
    }

    //Level 2 - puzzle , the player must arrange the puzzle pieces (shated window)
    public void Level2()
    {
        puzzle.GetComponent<Canvas>().enabled = true;
        hud.HiddenCollecionInterface();
        playerControler.speedMove = 0;
        playerControler.cameraPlayer.GetComponent<MouseLookScript>().enabled = false;
        puzzleManager.enabled = true;
    }
 
   


    //Replace window to shatted and destroy (Playsound glass destroy)
    void DestroyWindow()
    {
        for (int i = 0; i < windowsInteraction.Length; i++)
        {  
            GameObject destroywindow = windowsInteraction[i];    
            destroywindow = Instantiate(replacement.gameObject, destroywindow.transform.position, destroywindow.transform.rotation);
            destroywindow.GetComponent<AudioSource>().Play();
            windowsInteraction[i].gameObject.SetActive(false);
        }

    }
    public void PuzzleHidden()
    {
       puzzle.GetComponent<Canvas>().enabled = false;
    }

   public void WindowRenowable(short numerWindow)
    {
        windowsInteraction[numerWindow].SetActive(true);
    }


}
