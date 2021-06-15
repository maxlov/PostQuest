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

    /*private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("levelloader");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        EncounterThreshold = baseEncounterThreshold;
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
		{
            float Vertical = Input.GetAxisRaw("Vertical");
            float Horizontal = Input.GetAxisRaw("Horizontal");
            if (Vertical > 0 || Horizontal > 0)
            {
                Debug.Log(EncounterThreshold);
                if (Random.Range(0, 1000) <= EncounterThreshold)
                {
                    StartCoroutine(LoadLevel(Random.Range(1, 6)));
                }
                else
                {
                    EncounterThreshold += 1;
                }
            }
		}
    }

    public IEnumerator LoadLevel(int levelIndex)
	{
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
	}
}
