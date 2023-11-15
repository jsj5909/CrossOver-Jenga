
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataProcessor : MonoBehaviour
{
  
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


    void SaveAndSortData(List<BlockInfo> blocks)
    {
        _blockList = blocks;

        FindGradeLevels();
        

        _sortedBlockList = (blocks.OrderBy(b => b.grade).ThenBy(b => b.domain).ThenBy(b => b.cluster).ThenBy(b => b.id)).ToList<BlockInfo>();

       

        if (onDataReady != null)
            onDataReady(_gradeLevels,_sortedBlockList);
    }

    void FindGradeLevels()   
    {
        int i = 0;
        int gradeCount = 0;

        
        while(i<_blockList.Count && gradeCount < 3)
        {
            if(!_gradeLevels.Contains(_blockList[i].grade))
            {
                _gradeLevels.Add(_blockList[i].grade);
                gradeCount++;
            }
            i++;
            
        }
       
    }
}
