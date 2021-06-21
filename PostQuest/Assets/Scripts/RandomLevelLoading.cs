using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevelLoading : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public int baseEncounterThreshold = 5;
    private int EncounterThreshold;

    PersitentValues pValues;

    // on start find the values and if in overworld start rng encounter function
    private void Awake()
    {
        GameObject ValueManager = GameObject.Find("ValueManager");
        pValues = ValueManager.GetComponent<PersitentValues>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Instantiate(pValues.myPrefab, pValues.OverworldSpawn, Quaternion.identity);
            InvokeRepeating("loadEncounter", 1.0f, 1.0f);
        }
    }

    // randomly loads 'encounter' level. Runs every second
    void loadEncounter()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
		{
            float Vertical = Input.GetAxisRaw("Vertical");
            float Horizontal = Input.GetAxisRaw("Horizontal");
            if (Vertical > 0 || Horizontal > 0)
            {
                Debug.Log(EncounterThreshold);
                if (Random.Range(0, 100) <= EncounterThreshold)
                {
                    StartCoroutine(LoadLevel(Random.Range(1, 7)));
                }
                else
                {
                    EncounterThreshold += 1;
                }
            }
		}
    }
    // function to load levels. saves overworld pos if in overworld.
    public IEnumerator LoadLevel(int levelIndex)
	{
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            pValues.OverworldSpawn = GameObject.Find("Character").transform.position;
        }
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
	}
}
