using UnityEngine;

public class TrazzureSCript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    GameManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerStateManager>() != null){
            manager.EndGame();
        }
    }
}
