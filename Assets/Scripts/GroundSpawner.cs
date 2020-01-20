using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newGround = Instantiate(ground);
        newGround.SetActive(true);
        newGround.transform.position = new Vector3(0, -1, 60);
        Destroy(newGround, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            GameObject newGround = Instantiate(ground);
            newGround.SetActive(true);
            newGround.transform.position = new Vector3(0, -1, 70);
            Destroy(newGround, 15);
        }
    }
}
