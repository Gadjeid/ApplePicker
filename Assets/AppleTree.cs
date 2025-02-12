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

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    // Time between branch drops
    public float branchDropDelay = 3f;

    // Time between golden apple drops
    public float goldenAppleDropDelay = 5f;

    void Start()
    {
        Invoke("DropApple", 2f);
        Invoke("DropBranch", 2f);
        Invoke("DropGoldenApple", 2f);
    }

    void DropApple() 
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        Vector3 spawnPosition = transform.position + new Vector3(0, -3f, 0);
        apple.transform.position = spawnPosition;
        Invoke("DropApple", appleDropDelay);
    }

    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        Vector3 spawnPosition = transform.position + new Vector3(0, -3f, 0);
        branch.transform.position = spawnPosition;
        Invoke("DropBranch", branchDropDelay);
    }

    void DropGoldenApple()
    {
        GameObject goldenApple = Instantiate<GameObject>(goldenApplePrefab);
        Vector3 spawnPosition = transform.position + new Vector3(0, -3f, 0);
        goldenApple.transform.position = spawnPosition;
        Invoke("DropGoldenApple", goldenAppleDropDelay);
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
