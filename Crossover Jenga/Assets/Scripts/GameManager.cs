using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static List<GameObject> glassBlocks;
    
    void Start()
    {
        glassBlocks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            foreach (GameObject block in glassBlocks)
                Destroy(block);
    }
}
