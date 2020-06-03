using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //Puzzle Pieces
    [Header("Puzzle pieces")]
    public GameObject p1;
    public GameObject p2, p3, p4, p5, p6, p7;

    //Puzzle Field drop
    [Header("Puzzle field drop")]
    public GameObject f1;
    public GameObject f2, f3, f4, f5, f6, f7;

    Vector2 p1InitialPos, p2InitialPos, p3InitialPos, p4InitialPos, p5InitialPos, p6InitialPos, p7InitialPos;

    bool p1Correct, p2Correct, p3Correct, p4Correct, p5Correct, p6Correct, p7Correct = false;
    
    //Scripts
    [Header("Scripts")]
    public GameManager gameManager;
    public Hud hud;

    // Start is called before the first frame update
    void Start()
    {
       
        p1InitialPos = p1.transform.position;
        p2InitialPos = p2.transform.position;
        p3InitialPos = p3.transform.position;
        p4InitialPos = p4.transform.position;
        p5InitialPos = p5.transform.position;
        p6InitialPos = p6.transform.position;
        p7InitialPos = p7.transform.position;

    }
    //Drag()
    public void Dragp1()
    {
        p1.transform.position = Input.mousePosition;
    }
    public void Dragp2()
    {
        p2.transform.position = Input.mousePosition;
    }
    public void Dragp3()
    {
        p3.transform.position = Input.mousePosition;
    }
    public void Dragp4()
    {
        p4.transform.position = Input.mousePosition;
    }
    public void Dragp5()
    {
        p5.transform.position = Input.mousePosition;
    }
    public void Dragp6()
    {
        p6.transform.position = Input.mousePosition;
    }
    public void Dragp7()
    {
        p7.transform.position = Input.mousePosition;
    }

    //Drop
    public void Dropp1()
    {
        float Distance = Vector3.Distance(p1.transform.position, f1.transform.position);
        if(Distance<50)
        {
            p1.transform.position = f1.transform.position;
            p1Correct = true;
        }else
        {
            p1.transform.position = p1InitialPos;
            p1Correct = false;
        }
    }

    public void Dropp2()
    {
        float Distance = Vector3.Distance(p2.transform.position, f2.transform.position);
        if (Distance < 50)
        {
            p2.transform.position = f2.transform.position;
            p2Correct = true;
        }
        else
        {
            p2.transform.position = p2InitialPos;
            p2Correct = false;
        }
    }
    public void Dropp3()
    {
        float Distance = Vector3.Distance(p3.transform.position, f3.transform.position);
        if (Distance < 50)
        {           
            p3.transform.position = f3.transform.position;
            p3Correct = true;
        }
        else
        {
            p3.transform.position = p3InitialPos;
            p3Correct = false;
        }
    }
    public void Dropp4()
    {
        float Distance = Vector3.Distance(p4.transform.position, f4.transform.position);
        if (Distance < 50)
        {
            p4.transform.position = f4.transform.position;
            p4Correct = true;
        }
        else
        {
            p4.transform.position = p4InitialPos;
            p4Correct = false;
        }
    }
    public void Dropp5()
    {
        float Distance = Vector3.Distance(p5.transform.position, f5.transform.position);
        if (Distance < 50)
        {
            p5.transform.position = f5.transform.position;
            p5Correct = true;

        }
        else
        {
            p5.transform.position = p5InitialPos;
            p5Correct = false;
        }
    }
    public void Dropp6()
    {
        float Distance = Vector3.Distance(p6.transform.position, f6.transform.position);
        if (Distance < 50)
        {
            p6.transform.position = f6.transform.position;
            p6Correct = true;
        }
        else
        {
            p6.transform.position = p6InitialPos;
            p6Correct = false;
        }
    }
    public void Dropp7()
    {
        float Distance = Vector3.Distance(p7.transform.position, f7.transform.position);
        if (Distance < 50)
        {
            p7.transform.position = f7.transform.position;
            p7Correct = true;
        }
        else
        {
            p7.transform.position = p7InitialPos;
            p7Correct = false;
        }
    }

    private void Update()
    {
        if (p1Correct && p2Correct && p3Correct && p4Correct && p5Correct && p6Correct && p7Correct)
        {
            gameManager.Invoke("PuzzleHidden", 2.0f);
            hud.Invoke("PuzzleHidden", 2.0f);
            Invoke("ResetStartPositionPuzzle", 2.0f);
            ResetPuzzle();
            hud.ChangeCursorTips("Witraż ułożony");
            hud.checkWindowTrigger("Udało się odnowić zniszczenia");
        }
    }

    void ResetPuzzle()
    {
        p1Correct = false; 
        p2Correct = false;
        p3Correct = false;
        p4Correct = false;
        p5Correct = false;
        p6Correct = false;
        p7Correct = false;
    }

    public void ResetStartPositionPuzzle()
    {
        p1.transform.position = p1InitialPos;
        p2.transform.position = p2InitialPos;
        p3.transform.position = p3InitialPos;
        p4.transform.position = p4InitialPos;
        p5.transform.position = p5InitialPos;
        p6.transform.position = p6InitialPos;
        p7.transform.position = p7InitialPos;
        
    }

    
 
}
