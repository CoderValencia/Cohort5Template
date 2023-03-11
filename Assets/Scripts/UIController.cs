using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    //The UI Controller is a Singleton
    //An instance is a saved copy of this game object so that it can be accessed from anywhere
    public static UIController Instance { get; private set; }

    [Tooltip("The destructible of the player so we can tell if the game is over")]
    public Destructible playerDestructible;
    [Tooltip("A list of all the heart containers for the player")]
    public List<GameObject> heartContainers;
    [Tooltip("The lose screen to show upon death")]
    public GameObject loseScreen;
    [Tooltip("The text object to modify showing coin count")]
    public TMP_Text coinCountText;
    [Tooltip("The text object to modify showing ammo count")]
    public TMP_Text projectileCountText;

    //A var to know whether or not we have lost the game
    private bool hasLost = false;
    //The current coin coint in the game
    private int coinCount;

    //Awake happens once at the beginning of the game, even before Start()
    public void Awake()
    {
        //If we have an instance of a UI Controller already 
        if (Instance != null && Instance != this)
        {
            //Destroy ourselves so we never have more than 1 UiController
            //This is the primary attribute of a Singleton
            Destroy(this);
        }
        else
        {
            //If we don't, set the instance to this UiController
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //If the player is dead
        if (playerDestructible == null)
        {
            //Set has lost to true
            hasLost = true;

            //Let the game developer know we probably should have a player
            Debug.LogWarning("UI Controller has no Player object on Start");
        }

        //Set our coin count to 0
        coinCount = 0;
        //Call the modify coin count function to force a text update
        ModifyCoinCount(0);
    }

    // Update is called once per frame
    void Update()
    {
        //ask for the current hitpoints
        int healthPoints = playerDestructible.GetCurrentHitPoints();

        //For every heart in our heart list
        for( int i = 0; i < heartContainers.Count; i++ )
        {
            //If we have enough hitpoints...
            if( i < healthPoints )
            {
                //Turn it on
                heartContainers[i].SetActive(true);
            }
            else
            {
                //If not, turn it off
                heartContainers[i].SetActive(false);
            }
        }

        //If we are dead...
        if (hasLost == false && healthPoints <= 0)
        {
            //and if we have a lose screen...
            if (loseScreen != null)
            {
                //Show the lose screen
                loseScreen.SetActive(true);
            }
            else
            {
                //Otherwise just print to console
                Debug.Log("Lose Game");
            }

            //And set has lost to true
            hasLost = true;
        }
    }

    //Load a level by level name
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Restart level to start over
    public void RestartLevel()
    {
        //By just loading the same level again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Change the number of coins we have
    public void ModifyCoinCount(int numCoins)
    {
        //Add to the variable
        coinCount += numCoins;

        //If we have coin text...
        if (coinCountText != null)
        {
            //Change the text to our new count
            coinCountText.text = "X " + coinCount;
        }
    }

    //Change the ammo count
    public void SetProjectileCount(int totalProjectiles)
    {
        //If we have projectile text
        if (projectileCountText != null)
        {
            //Change the text to our new ammo count
            projectileCountText.text = "X " + totalProjectiles;
        }
    }
}
