using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float topBound = 30.0f;
    public float lowerBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // if an object goes past the players view in the game, remove that object
        if (transform.position.z > topBound)
        {
            Object.Destroy(gameObject);
        }else if (transform.position.z < lowerBound)
        {
            
            Object.Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
