using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnter : MonoBehaviour
{

    public GameObject boxtext;
    private PlayerHealth reManager;

    private void Start()
    {
        // Find the PlayerHeath script.
        reManager = Object.FindObjectOfType<PlayerHealth>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            // if player is in Trigger, show the Saving-Text & set this Spawn point active
            boxtext.SetActive(true);
            reManager.SetSpawnPoint(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set Saving-Text back to invisible.
            boxtext.SetActive(false);
        }
    }
}
