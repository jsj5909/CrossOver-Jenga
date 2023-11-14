using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class TowerBuilder : MonoBehaviour
{
    //[SerializeField] private Transform _tower1base;
    //[SerializeField] private Transform _tower2base;
    //[SerializeField] private Transform _tower3base;

    [SerializeField] private GameObject _glassBlock;
    [SerializeField] private GameObject _woodBlock;
    [SerializeField] private GameObject _stoneBlock;

    [SerializeField] private TMP_Text[] _towerLabels;
   

    private float _tower1HorizontalBaseX = -10f;
    private float _tower1HorizontalBaseZ = -2.5f;
    private float _tower1VerticalBaseX = -12.5f;
    private float _tower1VerticalBaseZ = 0;

    private float _tower2HorizontalBaseX = 5.9f;
    private float _tower2HoriztonalBaseZ = -2.5f;
    private float _tower2VerticalBaseX = 3.4f;
    private float _tower2VerticalBaseZ = 0;

    private float _tower3HorizontalBaseX = 21.8f;
    private float _tower3HorizontalBaseZ = -2.5f;
    private float _tower3VerticalBaseX = 19.3f;
    private float _tower3VerticalBaseZ = 0;

    private float _pieceHeight = 1.5f;
    private float _pieceWidth = 2.5f;

   // private float _zPosition = -2.5f;
    
    private void OnEnable()
    {
        DataProcessor.onDataReady += BuildTower;
    }

    private void OnDisable()
    {
        DataProcessor.onDataReady -= BuildTower;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   void BuildTower(List<string> gradeLevels, List<BlockInfo> blocks)
   {

        int height = 0;
        bool horizontal = true;
        int currentPiece = 0;
        int currentPieceInGroup = 0;
        int currentTower = 0;

        Transform pieceTransform;
        Debug.Log("GRADE COUNT = " + gradeLevels.Count);
        //Debug.Log("BLOCKS2: " + blocks.Count);
        foreach(string grade in gradeLevels)
        {
            List<BlockInfo> currentGradeList = (from b in blocks where b.grade == grade select b).ToList();
            // foreach (BlockInfo b in currentGradeList) b.PrintBlock();
            _towerLabels[currentTower].text = grade;


            Debug.Log("CURRENT GRADE LIST COUNT: " + currentGradeList.Count);
            while(currentPiece < currentGradeList.Count)
            {
                if(horizontal)
                {
                    pieceTransform = ComputeTransform(currentTower, currentPieceInGroup, height, horizontal);
                    ConfigurePiece(currentGradeList[currentPiece], pieceTransform);
                    currentPieceInGroup++;

                }
                else
                {
                    pieceTransform = ComputeTransform(currentTower, currentPieceInGroup, height, horizontal);
                    ConfigurePiece(currentGradeList[currentPiece], pieceTransform);
                    currentPieceInGroup++;
                }

                if(currentPieceInGroup % 3 == 0)
                {
                    height++;
                    horizontal = !horizontal;
                    currentPieceInGroup = 0; 
                }

                currentPiece++;
            }

            currentTower++;
            currentPiece = 0;
            currentPieceInGroup = 0;
            height = 0;
           
        }
      


   }
   
    void ConfigurePiece(BlockInfo block, Transform pieceTransform)
    {
        Vector3 piecePosition = Vector3.zero;

        Quaternion _pieceRotation;

        GameObject singlePiece = Instantiate(SelectBlock(block.mastery), pieceTransform.position, pieceTransform.rotation);

        if (block.mastery == 0)
            GameManager.glassBlocks.Add(singlePiece);

        Block pieceInfo = singlePiece.GetComponent<Block>();

        pieceInfo.LoadData(block);
       
    }

    Transform ComputeTransform(int currentTower, int currentPiece, int height, bool horizontal)
    {
        Transform finalTransform = _glassBlock.transform; 
        Vector3 piecePosition = Vector3.zero;
        Quaternion pieceRotation = Quaternion.identity;

        if (horizontal)
        {
            switch (currentTower)
            {
                case 0:
                    piecePosition = new Vector3(_tower1HorizontalBaseX, height * _pieceHeight, _tower1HorizontalBaseZ + _pieceWidth * currentPiece);
                    break;
                case 1:
                    piecePosition = new Vector3(_tower2HorizontalBaseX, height * _pieceHeight, _tower2HoriztonalBaseZ + _pieceWidth * currentPiece);
                    break;
                case 2:
                    piecePosition = new Vector3(_tower3HorizontalBaseX, height * _pieceHeight, _tower3HorizontalBaseZ + _pieceWidth * currentPiece);
                   
                    break;
                default:
                    break;
            }

            pieceRotation = Quaternion.AngleAxis(90, Vector3.up);
        }
        else
        {
            switch (currentTower)
            {
                case 0:
                    piecePosition = new Vector3(_tower1VerticalBaseX + _pieceWidth * currentPiece, height * _pieceHeight, _tower1VerticalBaseZ);
                    break;
                case 1:
                    piecePosition = new Vector3(_tower2VerticalBaseX + _pieceWidth * currentPiece, height * _pieceHeight, _tower2VerticalBaseZ);
                    break;
                case 2:
                    piecePosition = new Vector3(_tower3VerticalBaseX + _pieceWidth * currentPiece, height * _pieceHeight, _tower3VerticalBaseZ);
                    break;
                default:
                    break;
            }
        }
        finalTransform.position = piecePosition;
        finalTransform.rotation = pieceRotation;

        return finalTransform; 

        
    }

    private GameObject SelectBlock(int i)
    {
        if (i == 0)
        {
            
            return _glassBlock;
        }
        if (i == 1)
            return _woodBlock;

        return _stoneBlock;

    }

}
