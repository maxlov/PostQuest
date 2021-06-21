using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCode : MonoBehaviour
{
    public AudioSource success;
    public AudioClip successClip;

    public int levelTarget = 0;

    private GameObject LevelLoader;

    void Start()
    {
        LevelLoader = GameObject.Find("LevelLoader");
    }

    // send player  back to overworld on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LevelLoader.GetComponent<RandomLevelLoading>().LoadLevel(levelTarget));
        }
    }
}
