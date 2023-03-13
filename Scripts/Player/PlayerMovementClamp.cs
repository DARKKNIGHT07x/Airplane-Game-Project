using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementClamp : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed; 
    public float padding = 0.8f;
    float minX;
    float maxX;
    float minY;
    float maxY;

    void Start()
    {
        FindBoundaries();
    }

    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        //Debug.Log(minX);
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
        //Debug.Log(maxX);
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        //Debug.Log(minX);
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
        //Debug.Log(minX);
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*Speed;
        float deltaY = Input.GetAxis("Vertical")*Time.deltaTime*Speed;

        float newXpos = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);

        transform.position = new Vector2(newXpos, newYpos);

    }
}