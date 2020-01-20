using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float maxSize;
    public GameObject ground;
    private GameObject cube;
    private float speed = 0.2f;
    private int numberCube;

    public float maxTime = 5;
    private float timer = 0;
    private float timeBeforeDestroyed = 20;
    private int maxCube = 5;
    private int minCube = 1;

    private List<GameObject> listCubes;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        listCubes = new List<GameObject>();
        playerController = GameObject.Find("Camera Rig").GetComponent<PlayerController>();

        // Taille minimale d'un cube
        if (maxSize < 10)
        {
            maxSize = 40;
        }

        numberCube = Random.Range(1, 5);

        for (int i = 0; i < numberCube; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.tag = "Cube";
            listCubes.Add(cube);

            cube.transform.localScale = new Vector3(10, Random.Range(10, maxSize), 10);

            float cubeSizeY = cube.transform.localScale.y;

            cube.transform.position = new Vector3(Random.Range(-90, 90), cubeSizeY / 2 - 1, Random.Range(250,300));
            cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            Collider cubeCollider = cube.GetComponent<Collider>();
            cubeCollider.isTrigger = true;
            
            cube.AddComponent<Rigidbody>();
            Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
            cubeRigidbody.isKinematic = true;
            cubeRigidbody.useGravity = false;

            // Ajour du script CubeCollision.cs à chaque cube
            cube.AddComponent<CubeCollision>();

            Destroy(cube, timeBeforeDestroyed);
        }   
    }

    // Update is called once per frame
    void Update()
    {

        // Vitesse des cubes
        speed += (Time.deltaTime * 2 / 100);

        // Taille minimale d'un cube
        if (maxSize < 10)
        {
            maxSize = 40;
        }

        // Nombre maximal de cube
        maxCube += (int)speed;
        if (maxCube > 12)
        {
            maxCube = 12;
        }

        minCube += (int)speed;
        if (minCube > 7)
        {
            minCube = 7;
        }
        numberCube = Random.Range(minCube, maxCube);

        // Temps maximal avant création de nouveau cube
        maxTime -= speed;
        if (maxTime < 1)
        {
            maxTime = 1;
        }

        // Temps avant qu'un cube ne soit détruit
        if (maxTime > 1)
        {
            timeBeforeDestroyed = maxTime;
        } else
        {
            timeBeforeDestroyed = 0.25f;
        }
        

        if (timer > maxTime)
        {
            for (int i = 0; i < numberCube; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.tag = "Cube";
                listCubes.Add(cube);

                cube.transform.localScale = new Vector3(10, Random.Range(10, maxSize), 10);

                float cubeSizeY = cube.transform.localScale.y;

                cube.transform.position = new Vector3(Random.Range(-150, 150), cubeSizeY / 2 - 1, Random.Range(250, 300));
                cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

                Collider cubeCollider = cube.GetComponent<Collider>();
                cubeCollider.isTrigger = true;

                cube.AddComponent<Rigidbody>();
                Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
                cubeRigidbody.isKinematic = true;
                cubeRigidbody.useGravity = false;

                cube.AddComponent<CubeCollision>();

                Destroy(cube, 12);

                timer = 0;
            }
        }

        // Enlève de la liste si le GameObject n'existe plus
        listCubes.RemoveAll(GameObject => GameObject == null);

        //print(speed);

        // Change la position des cubes selon l'angle Z
        foreach (GameObject cube in listCubes)
        {
            float angleZ = playerController.getAngleZ();
            //print(angleZ);
            if (angleZ > 10)
            {
                cube.transform.position += new Vector3(0.5f + (speed / 500), 0, -speed);
            } else if (angleZ < -10)
            {
                cube.transform.position += new Vector3(-0.5f - (speed / 500), 0, -speed);
            } else
            {
                cube.transform.position += new Vector3(0, 0, -speed); //Vector3(angleZ, 0, -speed);
            }
        }

        // Incrémente le timer de 1 seconde
        timer += Time.deltaTime;
    }

}
