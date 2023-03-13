using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnableOnTrigger : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(gameObject + "enabled");
            gameObject.SetActive(true);
        }

    }
}
