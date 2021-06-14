using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevelLoading : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
            if (SceneManager.GetActiveScene().buildIndex == 0)
			{
                StartCoroutine(LoadLevel(Random.Range(1, 5)));
			}
			else
			{
                StartCoroutine(LoadLevel(0));
            }
		}
    }

    IEnumerator LoadLevel(int levelIndex)
	{
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
	}
}
