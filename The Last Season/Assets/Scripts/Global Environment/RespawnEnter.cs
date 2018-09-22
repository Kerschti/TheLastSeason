using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnter : MonoBehaviour {

    public GameObject boxtext;
    private PlayerHealth reManager;

    private void Start()
    {
        reManager = Object.FindObjectOfType<PlayerHealth>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))

        {
          
            boxtext.SetActive(true);
            reManager.SetSpawnPoint(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            boxtext.SetActive(false);
        }
    }
}
