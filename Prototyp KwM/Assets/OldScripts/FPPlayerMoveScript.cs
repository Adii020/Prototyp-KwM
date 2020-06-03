using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPlayerMoveScript : MonoBehaviour
{

    //Raycast 
    public float TargetDistance;

    // Move speed 
    public CharacterController controller;
    public float speedMove = 12f;

    //Gravity
    Vector3 velocity;
    public float gravity = -9.81f;

    //Coledted Item
    private List<string> colledtedItem = new List<string>();

    // Podpięcie skryptu
    public GameManagers gameManager;
    public InterfaceTimeline interfaceTimeline;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check count list collection item
        if (colledtedItem.Count == 21)
        {
            interfaceTimeline.InterfaceFieldShow();
        }

        // Move function
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speedMove * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
       
        // Interacion with window
        if (Input.GetKeyDown(KeyCode.E) && gameManager.windowsInteraction[0] != null && gameManager.animationInterface == false )
        {
          //  gameManager.windowInteraction = true;
            gameManager.animationInterface = true;  
        }
        

        // 2. get mouse position in world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

        //3. get direction vector from camera position to mouse position in world space
        Vector3 direction = worldMousePosition - Camera.main.transform.position;
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 10f))
        {

            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);

            // 5. Destroy game object
            if (hit.collider.gameObject.tag == "Piece")
            {
                if (Input.GetMouseButton(0))
                {
                    colledtedItem.Add(hit.collider.gameObject.name);
                    // Debug.Log(colledtedItem.ToString());

                    interfaceTimeline.setCollectionCount((short)colledtedItem.Count);
                    Destroy(hit.collider.gameObject);
                }else
                {
                    interfaceTimeline.GreenColorViewfinder();
                    //Debug.Log("Podnieś");
                    
                    interfaceTimeline.PickUpTextShow();
                }
            }
            else
            {
                interfaceTimeline.PickUpTextHidden();
                interfaceTimeline.RedColorViewfinder();
                Debug.DrawLine(Camera.main.transform.position, worldMousePosition, Color.red, 0.5f);
            }
            
        }else
        {

            interfaceTimeline.RedColorViewfinder();
            interfaceTimeline.PickUpTextHidden();
            
           
        }

    }

    private void LateUpdate()
    {
        if (gameManager.puzzlestart == true)
        {

            interfaceTimeline.CollectionInterfaceHidden();
            Debug.Log("Zaczynamy puzzle");
            interfaceTimeline.InterfaceFieldHidden();
            // Fraction of journey completed equals current distance divided by total distance.
            //float fractionOfJourney = Time.time / Vector3.Distance(gameObject.transform.position, new Vector3(2f, 2f, 2f));
           //  gameObject.GetComponent<CharacterController>().enabled = false;
              gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, interfaceTimeline.InterfaceFieldPosition(), Time.deltaTime*2);
             speedMove = 0;
          
            interfaceTimeline.PuzzleShow();
            interfaceTimeline.MousePosition();


            // gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, PuzzleStartPosition, Time.deltaTime * 2);

        }

        if(gameManager.puzzlestart == false)
        {
         
            speedMove = 10;
            interfaceTimeline.Invoke("PuzzleHidden", 1f);
           
        }
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "InterfaceField")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                gameManager.puzzlestart = true;
              
            }
            
        }
    }
   

   
   



}
