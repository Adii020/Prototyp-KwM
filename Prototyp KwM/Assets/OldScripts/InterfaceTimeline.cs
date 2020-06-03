using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceTimeline : MonoBehaviour
{

    private TextMeshProUGUI Date1;
    private TextMeshProUGUI Date2;
    private TextMeshProUGUI Date3;
    private TextMeshProUGUI Date4;
    private short startdata = 1881;
    private short currentdata;
    private short godata = 1881;
    //All timeline
    public bool animationIsPlay = false;
    public GameObject Timeline;
    private Vector2 startPosition, endPosition;
    //Interface field
    private GameObject InterfaceField;
    //Cekownik
    public Text PickUpText;
    private Image ViewFinder;
    // Podpięcie skryptu
    public GameManagers gameManager;
    // Collection Count
    private Text CountCollection; 
    private GameObject CollectionInterface;
    //Puzzle
    private GameObject Puzzle;
    private MouseLookScript CameraPlayerLookAt; //Skrypt LookAt off if Puzzle start
    void Start()
    {
        Date1 = GameObject.Find("Timeline/Date1").GetComponent<TextMeshProUGUI>();
        Date2 = GameObject.Find("Timeline/Date2").GetComponent<TextMeshProUGUI>();
        Date3 = GameObject.Find("Timeline/Date3").GetComponent<TextMeshProUGUI>();
        Date4 = GameObject.Find("Timeline/Date4").GetComponent<TextMeshProUGUI>();
        PickUpText = GameObject.Find("Canvas/PickUpText").GetComponent<Text>();
        CountCollection = GameObject.Find("CollectionInterface/CollectionCountText").GetComponent<Text>();
        ViewFinder = GameObject.Find("Canvas/ViewFinder").GetComponent<Image>();
        InterfaceField = GameObject.Find("Interface/InterfaceField");
        CollectionInterface = GameObject.Find("Canvas/CollectionInterface");
        CameraPlayerLookAt = GameObject.Find("FPPlayer/CameraPlayer").GetComponent<MouseLookScript>();

        //Puzzle
        Puzzle = GameObject.Find("Puzzle");
        PuzzleHidden();
        Puzzle.GetComponent<Canvas>().enabled = true;
      
        CollectionInterfaceHidden();
        CollectionInterface.GetComponent<Canvas>().enabled = true;
         InterfaceFieldHidden();
        startPosition = transform.position;
        currentdata = startdata;
        PickUpText.text = "Podnieś";
        CountCollection.text = "0 / 21";

      

        Date2.text = startdata.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    public void MousePosition()
    {
        Cursor.lockState = CursorLockMode.None;
        ViewFinder.transform.position = Input.mousePosition;
    }

    public void PuzzleShow()
    {
        CameraPlayerLookAt.enabled = false;
        Puzzle.SetActive(true);


    }
    public void PuzzleHidden()
    {
        CameraPlayerLookAt.enabled = true;
        Puzzle.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        ViewFinder.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    public void CollectionInterfaceShow()
    {
        CollectionInterface.SetActive(true);
    }
    public void CollectionInterfaceHidden()
    {
        CollectionInterface.SetActive(false);
    }

    public Vector3 InterfaceFieldPosition()
    {
        return InterfaceField.transform.position;
    }
    
    public void InterfaceFieldShow()
    {
        InterfaceField.gameObject.SetActive(true);
    }
    public void InterfaceFieldHidden()
    {
        InterfaceField.gameObject.SetActive(false);
    }
    public void PickUpTextShow()
    {
        PickUpText.gameObject.SetActive(true);
    }
    public void PickUpTextHidden()
    {
        PickUpText.gameObject.SetActive(false);
    }

    public void GreenColorViewfinder()
    {
        ViewFinder.color = new Color(0f, 255f, 0f, 0.5f);
        
    }
    public void RedColorViewfinder()
    {
        ViewFinder.color = new Color(255f, 0f, 0f, 0.5f);
    }

    //Animation Timeline data
    public void TimelineAnimation()
    {
        if (godata != currentdata)
        {
           
           // Date1.text = (currentdata - 1).ToString();
            Date2.text = currentdata.ToString();
            //Date3.text = (currentdata + 1).ToString();
            //Date4.text = (currentdata + 2).ToString();
            currentdata += 1;
        }
        else if (godata == currentdata && gameManager.animationInterface == true)
        {
            Date2.text = currentdata.ToString();
            //Stop animacji
            gameManager.animationInterface = false;
            gameManager.windowInteraction = true;
           // Debug.Log("elo");
           
            
            
        }
    }
    public short setStartData(short gotoData)
    {
        godata = gotoData;
        return godata;
    }

    public void setCollectionCount(short count)
    {
       CountCollection.text  = count.ToString() + "/ 21";
        
    }
    public void Timelineposition()
    {
        endPosition = new Vector2(startPosition.x, startPosition.y + 100);
        transform.position = Vector2.Lerp(transform.position, endPosition, Time.deltaTime * 2f);
    }

    
}
