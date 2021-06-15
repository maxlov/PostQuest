using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevelLoading : MonoBehaviour
{
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

    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
		{
            //overWorldCoors = 
		}
    }

    public IEnumerator LoadLevel(int levelIndex)
	{
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
	}
}
