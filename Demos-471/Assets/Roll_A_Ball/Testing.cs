using UnityEngine;

public class Testing : MonoBehaviour
{

    //int score = 0;
    public GameObject cube;
    private Transform t;
    float speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //:)
        //rotation += 0.001f;
        //t.Rotate(rotation, 0, 0);

        t.Translate(0, speed, 0);

        switch (t.position.y){

        case 10: 
            speed = -1;
            break;

        case -10: 
            speed = 1;
            break;

        default:
            speed = speed;
            break;
        }


        //if (t.position.x < 10){
        //    t.Translate(speed, 0, 0);
        //}else {
        //    t.Translate(-speed, 0, 0);
        //}
    }
}
