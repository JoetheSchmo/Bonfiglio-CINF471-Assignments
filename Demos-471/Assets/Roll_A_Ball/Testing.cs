using UnityEngine;

public class Testing : MonoBehaviour
{

    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(":)");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 444){
            score += 1;
            print(score);
            print(":D");
        }

        
        
        
    }
}
