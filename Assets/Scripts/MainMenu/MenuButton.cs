using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] string sceneName;


	// Update is called once per frame
	void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}

		if(animator.GetBool("pressed"))
        {
			if(thisIndex == 0)
            {
				SceneManager.LoadScene(sceneName);
            }
			if(thisIndex == 1)
            {
				SceneManager.LoadScene(sceneName);
            }
			if(thisIndex == 2)
            {
				Application.Quit();
				Debug.Log("Daar bomb die bike");
            }
        }
    }
}
