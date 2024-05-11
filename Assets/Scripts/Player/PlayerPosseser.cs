using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosseser : MonoBehaviour
{
    public GameObject glovePlayer;
    public GameObject catPlayer;
    public bool isPossesing = false;


    public GameObject NPCSpawnPoint;
    public GameObject catNPC;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPossesing == true)
        {
            glovePlayer.SetActive(true);
            catPlayer.SetActive(false);
            isPossesing = false;
            Instantiate(catNPC, NPCSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void UnPosses()
    {
        isPossesing = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Cat"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                glovePlayer.SetActive(false);
                catPlayer.SetActive(true);
                Destroy(other.gameObject);
                Invoke(nameof(UnPosses), 1);
            }
        }
    }
}
