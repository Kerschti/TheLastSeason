using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    public GameObject[] enemies;    //Enemy prefab to be spawned.
    public float spawnTime = 4f;    //Time until new Enemy spawns.
    public int spawnDistance = 30;  // Distance at which to spawn enemies.
    public int upperSpawnLimit = 2; //Upper limit of spawned Enemies.

    Vector3 dirVec = Vector3.zero;  //direction Vector, will be changed later according to vector of playerMovement.

    private GameObject player;          //Reference to player 
    private PlayerHealth playerHealth;  //Reference to players health script
    [HideInInspector]
    public int spawnCount = 0;         //Spawn Count.
    private bool isInvoking = true;      // Check if Enemies are spawning at the moment.
    private GameObject spawnInstance;
    private Collider spawnArea;         //Collider of the Area in which Enemies should be spawning.

    // Use this for initialization
    void Start()
    {
        // Get the Collider element of the SpawnArea.
        spawnArea = GetComponent<Collider>();
        // Find the Player.
        player = GameObject.FindGameObjectWithTag("Player");
        // Get players Health script.
        playerHealth = player.GetComponent<PlayerHealth>();
        // Start the repeated spawning of enemies.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    Vector3 GetSpawnPos()
    {
        // Calculate the position at which Enemies should be spawning.
        return player.transform.position + dirVec * spawnDistance;
    }

    /* 
     * Validating if the spawn position is in the spawnAreas bounds.
     * @param spawnPosition
     * @returns true, if point is in SpawnArea.
     * @returns false if not.
     *
     */
    bool ValidateSpawnPos(Vector3 spawnPos)
    {
        if (spawnArea.bounds.Contains(spawnPos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    void Spawn()
    {
        // no need to spawn enemies if player is dead.
        if (playerHealth.curHealth <= 0f) return;

        // no need to spawn Enemies if there are enough around already.
        if (spawnCount > upperSpawnLimit && spawnInstance) return;

        //Calculate where to spawn enemy.
        Vector3 spawnPos = GetSpawnPos();

        // if the spawn position is in Area...
        if (ValidateSpawnPos(spawnPos))
        {
            // add to spawn count when enemie is about to be instanciated.
            spawnCount++;
            // set the y a little higher so we don't spawn inside hills.
            spawnPos.y = 50f;
            // which enemie should be spawned?
            int enemyIndex = Random.Range(0, enemies.Length);
            //initialize Raycast.
            RaycastHit hit;
            //check where Raycast hits floor and set that point as floorpoint for enemy.
            if (Physics.Raycast(spawnPos, Vector3.down, out hit, 60f, LayerMask.GetMask("Floor")))
            {
                spawnPos.y = hit.point.y;
            }
            //Instantiate the enemy
            spawnInstance = Instantiate(enemies[enemyIndex], spawnPos, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // get the forward vector from player.
        dirVec = player.transform.forward;

        //if player isn't moving...
        if (dirVec != Vector3.zero)
        {
            // if enemies arent spawning...
            if (!isInvoking)
            {
                // start spawning enemies!
                InvokeRepeating("Spawn", spawnTime, spawnTime);
                isInvoking = true;
            }
        }
        else
        {
            // Stop spawning.
            CancelInvoke("Spawn");
            isInvoking = false;
        }

    }
}
