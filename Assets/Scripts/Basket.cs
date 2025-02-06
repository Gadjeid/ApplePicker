using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGo.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    
    void OnCollisionEnter(Collision coll) 
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")) 
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
        }
    }
}
