using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataProcessor : MonoBehaviour
{
    // Start is called before the first frame update
    private List<BlockInfo> _blockList;

    private List<BlockInfo> _sortedBlockList;

    private List<string> _gradeLevels;

    public static Action<List<string>,List<BlockInfo>> onDataReady;

    private void OnEnable()
    {
        Loader.onDataLoaded += SaveAndSortData;
    }

    private void OnDisable()
    {
        Loader.onDataLoaded -= SaveAndSortData;    
    }

    void Start()
    {
        _blockList = new List<BlockInfo>();
        _gradeLevels = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void SaveAndSortData(List<BlockInfo> blocks)
    {
        _blockList = blocks;

        FindGradeLevels();
        //begin data processing

        // var orderByResult = from b in _blockList
        //       orderby b.grade
        //       select b;

        // var orderByResult = blocks.OrderBy(b => b.grade).ThenBy(b => b.domain).ThenBy(b => b.cluster).ThenBy(b => b.id);

        _sortedBlockList = (blocks.OrderBy(b => b.grade).ThenBy(b => b.domain).ThenBy(b => b.cluster).ThenBy(b => b.id)).ToList<BlockInfo>();

        // foreach (BlockInfo b in _sortedBlockList) { b.PrintBlock(); }

        if (onDataReady != null)
            onDataReady(_gradeLevels,_sortedBlockList);
    }

    void FindGradeLevels()   
    {
        int i = 0;
        int gradeCount = 0;

       // Debug.Log(_blockList[0].grade);
        
        while(i<_blockList.Count && gradeCount < 3)
        {
            if(!_gradeLevels.Contains(_blockList[i].grade))
            {
                _gradeLevels.Add(_blockList[i].grade);
                gradeCount++;
            }
            i++;
            
        }
        //assume list is in order
        
        //Debug.Log("Grade Level Count: " + gradeCount);
       // foreach (string s in _gradeLevels)
           // Debug.Log(s);
    }
}
