using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] private List<Material> _materials;
    
    private MeshRenderer _mRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _mRenderer = GetComponent<MeshRenderer>();
        if (_mRenderer == null)
            Debug.LogError("Mesh Renderer on block is null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData(BlockInfo data)
    {
        Debug.Log("Mastery: " + data.mastery);
        //ApplyMaterial(data.mastery);
    }

    public void ApplyMaterial(int i)
    {
        //_mRenderer.materials[0] = _materials[i];
       // List<Material> mat = new List<Material>();

       // Material m = _materials[i];

       // _mRenderer.material = _mRenderer.materials[i];
    }

    private void OnMouseDown()
    {
        Debug.LogError(gameObject.name + " Clicked");
    }

}
