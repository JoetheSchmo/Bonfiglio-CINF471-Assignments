using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter()
    {
        health -= 1;
    }
}
