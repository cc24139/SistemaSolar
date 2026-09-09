using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class LookAtTarget : MonoBehaviour {

	 public GameObject target; // the target that the camera should look at
	 private VolumeController volumeController; // reference to the VolumeController script
	void Start () {
		if (target == null)
		{
			target = this.gameObject;
			Debug.Log("LookAtTarget target not specified. Defaulting to parent GameObject");
		}
		if(volumeController == null)
			volumeController = Camera.main.GetComponent<VolumeController>();
		
	}

	// Update is called once per frame
	void Update()
	{
		if (target != null)
		{
			Debug.Log("Olhando para o alvo: " + target.name);
			transform.LookAt(target.transform);
			Camera.main.transform.LookAt(target.transform);
		}
			if (volumeController != null && target.GetComponent<AudioSource>() != null)
			{
				volumeController.SetNewSound(target.GetComponent<AudioSource>());
			}

			else
			{
				Debug.LogWarning("VolumeController or AudioSource is null. Cannot set new sound.");
			}
		}
	}
	

