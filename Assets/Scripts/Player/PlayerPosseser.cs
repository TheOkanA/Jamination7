using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosseser : MonoBehaviour
{
    public GameObject glovePlayer;
    public GameObject catPlayer;
    public GameObject truckPlayer;
    public GameObject manavPlayer;
    public string possesionName = "Glove";
    public bool isPossesing = false;
    public Walk walk;


    public GameObject NPCSpawnPoint;
    public GameObject catNPC;
    public GameObject truckNPC;
    public GameObject manavNPC;

    void Start()
    {
        walk = GetComponent<Walk>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPossesing == true)
        {
            glovePlayer.SetActive(true);
            catPlayer.SetActive(false);
            truckPlayer.SetActive(false);
            manavPlayer.SetActive(false);
            isPossesing = false;
            walk.jump = 350;
            walk.moveSpeed = 3f;
            NPCSpawner();
            possesionName = "Glove";
        }
    }

    public void UnPosses()
    {
        isPossesing = true;
    }   

    public void NPCSpawner()
    {
        if(possesionName == "Cat")
        {
            Instantiate(catNPC, NPCSpawnPoint.transform.position, Quaternion.identity);
        }

        if(possesionName == "FireTruck")
        {
            Instantiate(truckNPC, NPCSpawnPoint.transform.position, Quaternion.identity);
        }

        if(possesionName == "Manav")
        {
            Instantiate(manavNPC, NPCSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Cat"))
        {
            if(Input.GetKeyDown(KeyCode.E) && possesionName == "Glove")
            {
                glovePlayer.SetActive(false);
                catPlayer.SetActive(true);
                Destroy(other.gameObject);
                walk.jump = 550;
                possesionName = "Cat";
                Invoke(nameof(UnPosses), 1);
            }
        }

        if(other.CompareTag("FireTruck"))
        {
            if(Input.GetKeyDown(KeyCode.E) && possesionName == "Glove")
            {
                glovePlayer.SetActive(false);
                truckPlayer.SetActive(true);
                Destroy(other.gameObject);
                walk.jump = 0;
                walk.moveSpeed = 6f;
                possesionName = "FireTruck";
                Invoke(nameof(UnPosses), 1);
            }
        }

        if(other.CompareTag("Manav"))
        {
            if(Input.GetKeyDown(KeyCode.E) && possesionName == "Glove")
            {
                glovePlayer.SetActive(false);
                manavPlayer.SetActive(true);
                Destroy(other.gameObject);
                walk.jump = 0;
                possesionName = "Manav";
                Invoke(nameof(UnPosses), 1);
            }
        }
    }
}
