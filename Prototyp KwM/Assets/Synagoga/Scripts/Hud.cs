using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    //Celownik
    private Text cursorTips;
    private Image viewFinder;

    // Collection Count and Image
    private Text collectionCountText;
    private RawImage collectionImage;

    // List Window Trigger
    public GameObject windowTrigger1;
    public GameObject windowTrigger2;
    public GameObject windowTrigger3;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        cursorTips = GameObject.Find("HUD/CursorTipsText").GetComponent<Text>();
        viewFinder = GameObject.Find("HUD/ViewFinder").GetComponent<Image>();
        collectionCountText = GameObject.Find("HUD/CollectionCountText").GetComponent<Text>();
        collectionImage = GameObject.Find("HUD/CollectionIcon").GetComponent<RawImage>();
        collectionImage = GameObject.Find("HUD/CollectionIcon").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GreenCursor()
    {
        viewFinder.color = new Color(0f, 255f, 0f, 0.5f);
    }

    public void RedCursor()
    {
        viewFinder.color = new Color(255f, 0f, 0f, 0.5f);
    }

    public void ChangeCursorTips(string text)
    {
        cursorTips.text = text;
    }

    public void ShowCollecionInterface()
    {
        collectionCountText.enabled = true;
        collectionImage.enabled = true;
    }
    public void HiddenCollecionInterface()
    {
        collectionCountText.enabled = false;
        collectionImage.enabled = false;
    }
    public void SetCollectionCount(short count, short total)
    {
       collectionCountText.text = count.ToString() + "/ " + total;
    }

    public void ShowWindowTrigger()
    {
        windowTrigger1.SetActive(true);
        windowTrigger1.GetComponent<ParticleSystem>().Play();
        windowTrigger2.SetActive(true);
        windowTrigger2.GetComponent<ParticleSystem>().Play();
        windowTrigger3.SetActive(true);
        windowTrigger3.GetComponent<ParticleSystem>().Play();
    }

    public void MousePosition()
    {
        Cursor.lockState = CursorLockMode.None;
        viewFinder.transform.position = Input.mousePosition;
    }

    public void PuzzleHidden()
    {
        ChangeCursorTips("");
        Cursor.lockState = CursorLockMode.Locked;
        viewFinder.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
   
    public void checkWindowTrigger(string tekst)
    {
        if (windowTrigger1.gameObject.activeSelf == false && windowTrigger2.gameObject.activeSelf == false && windowTrigger3.gameObject.activeSelf == false)
        {
            ChangeCursorTips(tekst);
        }
        if (windowTrigger1.gameObject.activeSelf == false)
        {
            gameManager.WindowRenowable(0);
        }
        if (windowTrigger2.gameObject.activeSelf == false)
        {
            gameManager.WindowRenowable(1);
        }
        if (windowTrigger3.gameObject.activeSelf == false)
        {
            gameManager.WindowRenowable(2);
        }
    }
    
    /*
    public void PuzzleHidden()
    {
        CameraPlayerLookAt.enabled = true;
        Puzzle.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        ViewFinder.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    */
    /*
    public void FinishPuzzle()
    {
        if (p1Correct && p2Correct && p3Correct && p4Correct && p5Correct && p6Correct && p7Correct)
        {
            Cursor.lockState = CursorLockMode.Locked;
            hud.ViewFinder.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        }
    }*/

}
