using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool jenga = false;
    
    private static GameManager _instance;



    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager instance is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

    }



    public List<GameObject> glassBlocks;
    
    void Start()
    {
        glassBlocks = new List<GameObject>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            foreach (GameObject block in glassBlocks)
                Destroy(block);
    }
}
