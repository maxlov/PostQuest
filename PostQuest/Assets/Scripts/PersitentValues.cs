using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersitentValues : MonoBehaviour
{
    public int score;
    public Vector3 OverworldSpawn = new Vector3 (-130, 12, -530);
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        OverworldSpawn = GameObject.Find("Character").transform.position;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
