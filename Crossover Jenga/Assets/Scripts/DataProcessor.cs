using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataProcessor : MonoBehaviour
{
    // Start is called before the first frame update
    private List<BlockInfo> _blockList;


    private void OnEnable()
    {
        Loader.onDataLoaded += SaveData;
    }

    private void OnDisable()
    {
        Loader.onDataLoaded -= SaveData;    
    }

    void Start()
    {
        _blockList = new List<BlockInfo>();      
    }

    // Update is called once per frame
    void Update()
    {
        var orderByResult = from b in _blockList
                            orderby b.domain
                            select b;

    }

    void SaveData(List<BlockInfo> blocks)
    {
        _blockList = blocks;
        //begin data processing

       // var orderByResult = from b in _blockList
                     //       orderby b.grade
                     //       select b;

        var orderByResult = blocks.OrderBy(b => b.grade).ThenBy(b => b.domain).ThenBy(b => b.cluster).ThenBy(b => b.id);
                            
        foreach (BlockInfo b in orderByResult) { b.PrintBlock(); }
    }
}
