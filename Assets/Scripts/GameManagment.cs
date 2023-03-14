using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerTime;
  
    

    public void Update()
    {
       

        if (playerTime != null) {
            playerTime.text = PlayerPrefs.GetString("Player Time");
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("BodegaLevel");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("BodegaNarrative");
    }

}
