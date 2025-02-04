using UnityEngine;

public class SpaceObjects : MonoBehaviour

//Okay, so the goal of this was just to have the objects in the backround move but aparently I just
//can NOT figure it out :(

{
    private Transform t;
    private float startY, lowY, highY;
    float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = GetComponent<Transform>();

        //startY = t.position.y;

        speed = Random.Range(0.001f, 0.01f);

        highY = (t.position.y + Random.Range(1, 4));
        lowY = (t.position.y - Random.Range(1, 4));

        t.Translate(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //:)
        //rotation += 0.001f;
        //t.Rotate(rotation, 0, 0);

        if (t.position.y == highY){
            t.Translate(0, -speed, 0);
        }
        
        if (t.position.y == lowY){
            t.Translate(0, speed, 0);            
        }

        //switch (t.position.y){

        //case highY: 
        //    speed = -0.001f;
        //    break;

        //case lowY: 
        //    speed = 0.001f;
        //    break;

        //default:
        //    speed = speed;
        //    break;
        //}
    }
}
