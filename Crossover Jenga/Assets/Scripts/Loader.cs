using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

using System;

public class Loader : MonoBehaviour
{


    public static Action<List<BlockInfo>> onDataLoaded;

    public List<BlockInfo> allBlocks;

    public BlockInfo currentBlock;

    // Start is called before the first frame update
    void Start()
    {
        allBlocks = new List<BlockInfo>() ;
        
      
        

        StartCoroutine(LoadData());
    }

    private IEnumerator LoadData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"))
        {

            yield return request.SendWebRequest();

            if (request.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error: " + request.error);
            }
            else
            {
               // Debug.Log("Received: " + request.downloadHandler.text);

                string jData = request.downloadHandler.text;

                BlockInfo data = new BlockInfo();

                JsonSerializer serializer = new JsonSerializer();
              
                allBlocks = (List<BlockInfo>)JsonConvert.DeserializeObject<List<BlockInfo>>(jData);

                // foreach (BlockInfo block in allBlocks) { block.PrintBlock(); }

                if (onDataLoaded != null)
                    onDataLoaded(allBlocks);

            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}


//jData.Trim('[');
//jData.Trim(']');

//Debug.Log(jData);

//string[] blocks = new string[200];

//blocks = jData.Split('{','}');



//List<BlockInfo> allBlocks = new List<BlockInfo>(); 

//foreach(string item in blocks)
//{

//    string temp = '{' + item + '}';
//    Debug.Log(item);
//    // Debug.Log(temp);
//     if (item == "[" || item == "]" || item == ",") continue;
//    //item.Insert(0, "{");
//    //item.Insert(item.Length - 1, "}");


//      allBlocks.Add(JsonUtility.FromJson<BlockInfo>(temp));

//}
