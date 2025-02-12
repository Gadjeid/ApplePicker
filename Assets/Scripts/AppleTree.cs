using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject branchPrefab;
    public GameObject goldenApplePrefab;

    // Speed at which the Apple Tree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between object instantiations
    public float dropDelay = 1f;

    void Start()
    {
        Invoke("DropObject", 2f);
    }

    void DropObject()
    {
        // Generate a random number to decide which object to drop
        float randomChance = Random.value;

        // 80% chance for Apple, 15% for Branch, 5% for GoldenApple
        if (randomChance < 0.8f)
        {
            // 80% chance - Drop an apple
            Instantiate(applePrefab, GetSpawnPosition(), Quaternion.identity);
        }
        else if (randomChance < 0.95f)
        {
            // 15% chance - Drop a branch
            Instantiate(branchPrefab, GetSpawnPosition(), Quaternion.identity);
        }
        else
        {
            // 5% chance - Drop a golden apple
            Instantiate(goldenApplePrefab, GetSpawnPosition(), Quaternion.identity);
        }

        // Call DropObject again after the specified delay
        Invoke("DropObject", dropDelay);
    }

    // Method to get the spawn position for the objects
    Vector3 GetSpawnPosition()
    {
        return transform.position + new Vector3(0, -3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge) 
        {
            speed = Mathf.Abs(speed); // Move right
        } else if (pos.x > leftAndRightEdge) 
        {
            speed = -Mathf.Abs(speed); // Move left
        } 
    }

    void FixedUpdate() 
    {
        if (Random.value < changeDirChance) {
            speed *= -1; // Change direction
        }
    }
}
