using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShattingTrigger : MonoBehaviour
{

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "TempleFloor")
        {
            if (this.gameObject.GetComponent<AudioSource>().enabled == true)
        {
                this.GetComponent<AudioSource>().Play();
                
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "TempleFloor")
        {
            if (this.gameObject.GetComponent<AudioSource>().enabled == true)
            {

                SoundInvoke();
                this.Invoke("DelaySound", 0.2f);
            }
        }
    }
    private void SoundInvoke()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = false;
    }
    private void DelaySound()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = true;
    }
}
