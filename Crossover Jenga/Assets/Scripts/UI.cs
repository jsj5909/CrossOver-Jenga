
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] public Text gradeDomainText;
    [SerializeField] public Text ClusterText;
    [SerializeField] public Text idDescriptionText;

    [SerializeField] public GameObject infoPane;

    


    private static UI _instance;

    public static UI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI instance is null");
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


    public void ResetPressed()
    {
        GameManager.Instance.jenga = false;
        UI.Instance.infoPane.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void JengaPressed()
    {
        GameManager.Instance.jenga = !GameManager.Instance.jenga;
    }
    
}
