using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [Tooltip("How many coins to give the player on pickup")]
    public int coinValue = 1;
    [Tooltip("The sound to play on pickup, if any")]
    public AudioClip pickupSound;

    //Whenever anything touches us...
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Check to see if the thing that touched us has a player controller
        PlayerController playerController =
            collision.gameObject.GetComponent<PlayerController>();

        //If it does...
        if (playerController && UIController.Instance != null)
        {
            //Pick it up!
            OnPickup();
        }
    }

    //Function called on pickup
    public void OnPickup()
    {
        //Tell the UI Controller Singleton to add coins
        UIController.Instance.ModifyCoinCount(coinValue);

        //If we have an audio source and a sound...
        if(GetComponent<AudioSource>() && pickupSound)
        {
            //Play the sound!
            GetComponent<AudioSource>().PlayOneShot(pickupSound);
        }

        //Turn off our collider
        GetComponent<Collider2D>().enabled = false;

        //Turn off our sprite renderer
        if (GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        //Destroy ourself after 5 seconds (so there is time for the sound to play)
        Invoke("Die", 5f);
    }

    public void Die()
    {
        //On die we just destroy (AKA get deleted)
        Destroy(gameObject);
    }
}
