using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCode : MonoBehaviour
{
    private float bobIntensity = .25f;
    private float bobFrequency = .25f;
    float rotateSpeed = 50.0f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private GameObject GameManager;

    public AudioSource pickup;
    public AudioClip pickupClip;
    //public AudioSource paper;
    //public AudioSource box;

    public string collectibleType = "letter";
    int value = 0;

    // sets value of collectible based on kind
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        posOffset = transform.position;
        switch (collectibleType)
        {
            case "box":
                value = 1000;
                break;
            case "scroll":
                value = 500;
                break;
            default:
                value = 200;
                break;
        }
    }

    // Adds nice little spin and bob to the collectible
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * bobFrequency) * bobIntensity;

        transform.position = tempPos;

        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
    // plays sound, updates score, and destroys self on player collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickup.PlayOneShot(pickupClip);
            GameManager.GetComponent<ScoreManager>().UpdateScore(value);
            Destroy(gameObject, .2f);
        }
    }
}
