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
             
                string jData = request.downloadHandler.text;


                JsonSerializer serializer = new JsonSerializer();
              
                allBlocks = (List<BlockInfo>)JsonConvert.DeserializeObject<List<BlockInfo>>(jData);

               
                if (onDataLoaded != null)
                    onDataLoaded(allBlocks);

            }
        }
        
    }

}
