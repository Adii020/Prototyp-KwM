using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{

    //use to Replace shatted window
    public GameObject replacement;
    // check to start interaction
    public bool windowInteraction = false;
    public bool animationInterface = false;
    public bool puzzlestart = false;
    //Array window interaction
    public GameObject[] windowsInteraction;
    public AudioSource GameManageraudio;

    public AudioClip destroywindowsound;
    public AudioClip bombsound;
    //Particle bomb
    public Transform bompParticlefield;
    public InterfaceTimeline interfaceTimeline;
    // public GameObject windowsInteraction;


    // Start is called before the first frame update
    void Start()
    {
        bompParticlefield.GetComponent<ParticleSystem>().Pause();
        
    }

    // Update is called once per frame
    void Update()
    {
        //check start windowinteraction and interaction was't finished
        if (windowInteraction == true)
        {
           // Debug.Log("Start sound");
           
            Invoke("PlaySoundBomb", 0f);
            Invoke("DestroyWindow", 2.8f);
            interfaceTimeline.Invoke("CollectionInterfaceShow", 6f);
            
            windowInteraction = false;
        }
       if (animationInterface == true)
            {
                interfaceTimeline.setStartData(1914);

                interfaceTimeline.Invoke("Timelineposition", 0f);

                interfaceTimeline.Invoke("TimelineAnimation", 1f);
                
            
        }

       
    }

   
  
  /*  // 
    public IEnumerator TimelinePositionAnimation()
    {
        interfaceTimeline.Timelineposition();
        yield return new WaitForSeconds(2.5f);
    }
    public IEnumerator TimelineAnimationdata()
    {

        interfaceTimeline.TimelineAnimation();
        yield return StartCoroutine(TimelinePositionAnimation());
    }
    public IEnumerator WindowInteraction()
    {

       if (windowInteraction == true && windowsInteraction[0] != null)
        {
            Invoke("DestroyWindow", 3.8f);
            Invoke("PlaySoundBomb", 0f);
            this.windowInteraction = false;
            yield return StartCoroutine(TimelineAnimationdata());
        }
}
*/
    //Dżwięki
    void PlayWindowDestroySound()
    {
        GameManageraudio.PlayOneShot(destroywindowsound, 0.3f);
    }

    void PlaySoundBomb()
    {
        bompParticlefield.GetComponent<ParticleSystem>().Play();
        GameManageraudio.PlayOneShot(bombsound, 0.3f);
    }

    //Destroy window object (replace to pieces)
    void DestroyWindow()
    {
      
        for (int i = 0; i < windowsInteraction.Length; i++)
        {
            
            GameObject destroywindow = windowsInteraction[i];
            PlayWindowDestroySound();
           
            destroywindow = GameObject.Instantiate(replacement, destroywindow.transform.position, destroywindow.transform.rotation);
         
            Destroy(windowsInteraction[i].gameObject);


        }

    }
    

}
