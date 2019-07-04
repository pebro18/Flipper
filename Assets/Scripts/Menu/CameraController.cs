using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Animator anim;

    public AudioSource buttonClick;

    void Awake () {
		anim = GetComponent<Animator> ();
	}

	public void ToSettings()
	{
        //anim.SetBool ("InOptions", true);
        //   anim.SetBool("InMenu", false);
        buttonClick.Play();
        anim.Play("ToOptions");
	}

	public void OptionsToMenu()
	{
        //anim.SetBool ("InMenu", true);
        //      anim.SetBool("InOptions", false);
        buttonClick.Play();
        anim.Play("ToMenu");
	}

    public void ToRules()
    {
        buttonClick.Play();
        anim.Play("ToRules");
    }

    public void RulesToMenu()
    {
        buttonClick.Play();
        anim.Play("RulesToMenu");
    }

}
