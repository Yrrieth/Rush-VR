using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    //public GameManager gameManager;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.tag == "MainCamera"
        if (other.gameObject.name == "Main Camera")
        {
            Debug.Log("Touché");
            //Time.timeScale = 0;
            //gameManager.gameOver();
            gameManager.GetComponent<GameManager>().gameOver();
            
        }
    }
}
