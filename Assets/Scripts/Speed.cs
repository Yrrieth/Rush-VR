using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    private static float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        GetComponent<UnityEngine.UI.Text>().text = "Speed : " + speed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        speed += (Time.deltaTime * 2 / 100);
        GetComponent<UnityEngine.UI.Text>().text = "Speed : " + speed.ToString();
    }
}
