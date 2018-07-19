using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innervocie : MonoBehaviour {

    public AudioClip whatHappened;
    public AudioClip GoodLandingArea;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
	}
	
	void OnFindClearArea()
    {
        print(name + " OnFindClearArea");
        audioSource.clip = GoodLandingArea;
        audioSource.Play();

        Invoke("CallHeli", GoodLandingArea.length + 1f);
    }

    void CallHeli()
    {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}
