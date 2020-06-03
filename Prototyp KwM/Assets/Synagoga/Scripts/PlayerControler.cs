using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //LOOK MOUSE
    // Look Sensitivity
    public float mouseSensitivity = 100f;
    public Camera cameraPlayer;

    //MOVE
    // Move speed 
    public CharacterController controller;
    public float speedMove;
    //Gravity
    Vector3 velocity;
    public float gravity = -9.81f;

    //Coledted Item
    private List<string> colledtedItem = new List<string>();

    // SCRIPTS
    public GameManager gameManager;
    public Hud hud;

    private void Start()
    {
        //Stay Cursor to FirstPersonCamera 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(gameManager.levelNumber==1 && colledtedItem.Count < 21)
        {
            RaycastLook();    
        }
    }

    private void Move()
    {
        // Move function
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speedMove * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMove = 30f;
        }else
        {
            speedMove = 20f;
        }
    }
    private void RaycastLook()
    {
        // 1. get mouse position in world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
        //2. get direction vector from camera position to mouse position in world space
        Vector3 direction = worldMousePosition - Camera.main.transform.position;
        //3. if raycast hit distance <= 10 and direction is camera look at 
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 10f))
        {
            // 5. Destroy game object
            if (hit.collider.gameObject.tag == "WindowPiece")
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
                if (Input.GetMouseButton(0))
                {
                        colledtedItem.Add(hit.collider.gameObject.name);
                        hud.SetCollectionCount((short)colledtedItem.Count, 21);
                        Destroy(hit.collider.gameObject);
                    if (colledtedItem.Count == 21)
                    {
                        hud.RedCursor();
                        hud.ChangeCursorTips("");
                        hud.ShowWindowTrigger();     
                    }
                }
                else
                 {
                        hud.GreenCursor();
                        hud.ChangeCursorTips("Podnieś");               
                }
            }
            else
            {
               
                hud.ChangeCursorTips("");
                hud.RedCursor();
                Debug.DrawLine(Camera.main.transform.position, direction, Color.red, 0.5f);
            }
        }
        //4. if raycast hit distance < 10 and direction is camera look at 
        else
        {
            hud.RedCursor();
            hud.ChangeCursorTips("");
          
        }
    }
}
