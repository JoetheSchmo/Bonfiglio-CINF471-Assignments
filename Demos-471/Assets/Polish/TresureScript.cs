using UnityEngine;

public class TresureScript : MonoBehaviour
{

    [SerializeField]
    GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FP_Controller>() != null){
            manager.EndGame();
        }
    }
}
