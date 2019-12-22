using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float maxSize;
    public GameObject ground;
    private GameObject cube;
    public float speed;
    private int numberCube;

    public float maxTime = 5;
    private float timer = 0;

    private List<GameObject> listCubes;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        listCubes = new List<GameObject>();

        // Taille minimale
        if (maxSize < 10)
        {
            maxSize = 10;
        }

        numberCube = Random.Range(1, 5);

        for (int i = 0; i < numberCube; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            listCubes.Add(cube);

            cube.AddComponent<BoxCollider>();
            cube.transform.localScale = new Vector3(10, Random.Range(10, maxSize), 10);

            float cubeSizeY = cube.transform.localScale.y;

            cube.transform.position = new Vector3(Random.Range(-90, 90), cubeSizeY / 2 - 1, Random.Range(250,300));
            cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Destroy(cube, 15);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        numberCube = Random.Range(1, 5);
        if (timer > maxTime)
        {
            for (int i = 0; i < numberCube; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                listCubes.Add(cube);

                cube.AddComponent<BoxCollider>();
                cube.transform.localScale = new Vector3(10, Random.Range(10, maxSize), 10);

                float cubeSizeY = cube.transform.localScale.y;

                cube.transform.position = new Vector3(Random.Range(-90, 90), cubeSizeY / 2 - 1, Random.Range(250, 300));
                cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

                timer = 0;
                Destroy(cube, 15);
            }
        }

        // Enlève de la liste si le GameObject n'existe plus
        listCubes.RemoveAll(GameObject => GameObject == null);

        foreach (GameObject cube in listCubes)
        {
            //float angleZ = playerController.getAngleZ();
            cube.transform.position += new Vector3(0, 0, -speed); //Vector3(angleZ, 0, -speed);
        }

        // Incrémente le timer de 1 seconde
        timer += Time.deltaTime;
    }
}
