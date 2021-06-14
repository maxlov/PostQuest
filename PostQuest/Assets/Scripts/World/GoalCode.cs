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

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //success.PlayOneShot(successClip);
            StartCoroutine(LevelLoader.GetComponent<RandomLevelLoading>().LoadLevel(levelTarget));
        }
    }
}
