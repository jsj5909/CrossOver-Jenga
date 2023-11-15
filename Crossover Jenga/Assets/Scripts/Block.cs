
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{


    [SerializeField] private Text[] _blockLabels; 
    
    private MeshRenderer _mRenderer;

    private BlockInfo _info;
    
    
    void Start()
    {
        _mRenderer = GetComponent<MeshRenderer>();
        if (_mRenderer == null)
            Debug.LogError("Mesh Renderer on block is null");
    }

  
    public void LoadData(BlockInfo data)
    {
       
        _info = data;

        if(data.mastery == 1)
        {
            _blockLabels[0].text = "LEARNED";
            _blockLabels[1].text = "LEARNED";
        }
        if(data.mastery == 2)
        {
            _blockLabels[0].text = "MASTERED";
            _blockLabels[1].text = "MASTERED";
        }
    }

   

    private void OnMouseOver()
    {
        if(GameManager.Instance.jenga)
        {
            if(Input.GetMouseButtonDown(0))
                Destroy(this.gameObject);
            return;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            UI.Instance.infoPane.SetActive(true);
            UI.Instance.gradeDomainText.text = _info.grade + ":  " + _info.domain;
            UI.Instance.ClusterText.text = _info.cluster;
            UI.Instance.idDescriptionText.text = _info.id + ":  " + _info.standarddescription;

        }
    }

}
