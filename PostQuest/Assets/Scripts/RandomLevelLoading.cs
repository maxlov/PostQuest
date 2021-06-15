using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevelLoading : MonoBehaviour
{
    
    /*
    private static RandomLevelLoading _instance = null;
    protected RandomLevelLoading() {}

    public static RandomLevelLoading Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RandomLevelLoading();
            }
            return _instance;
        }
    }
    */
    public Animator transition;
    public float transitionTime = 1f;

    public int baseEncounterThreshold = 5;
    private int EncounterThreshold;

    private void Awake()
    {
        EncounterThreshold = baseEncounterThreshold;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
		{
            float Vertical = Input.GetAxisRaw("Vertical");
            float Horizontal = Input.GetAxisRaw("Horizontal");
            if (Vertical > 0 || Horizontal > 0)
            {
                if (Random.Range(0, 100) <= EncounterThreshold)
                {
                    StartCoroutine(LoadLevel(Random.Range(1, 5)));
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
