using UnityEngine;
using UnityEngine.Rendering;

public class VolumeController : MonoBehaviour
{
    public Volume volume;
    public Camera mainCamera;
    private AudioSource atualAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (volume == null)
        {
            volume = GetComponent<Volume>();
            if (volume == null)
            {
                Debug.LogError("Volume component not found on this GameObject.");
            }
            atualAudioSource = mainCamera.GetComponent<AudioSource>();
            if (atualAudioSource == null)
            {
                Debug.Log("AudioSource component not found on the main camera.");
            }
            else
            {
                Debug.Log("AudioSource found on the main camera: " + atualAudioSource.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetNewSound(AudioSource newSound)
    {
        if (atualAudioSource == null)
        {
            atualAudioSource = mainCamera.GetComponent<AudioSource>();
            if (atualAudioSource == null)
            {
                Debug.LogError("AudioSource component not found on the main camera.");
                return;
            }
        }
        if (newSound != null)
        {
            //caso for o mesmo som, não aplica novamente (ficaria reiniciando o som)
            if (atualAudioSource.clip == newSound.clip && atualAudioSource.isPlaying)
            {
                return;
            }
            else
            {
                ApplyNewSound(newSound);
            }
        }
        else
        {
            Debug.LogWarning("Attempted to set a null AudioSource.");
        }
    }

    private void ApplyNewSound(AudioSource newSound)
    {

        if (newSound != null)
        {
            atualAudioSource.Stop();
            atualAudioSource.clip = newSound.clip;
            atualAudioSource.Play();
            Debug.Log("New sound set: " + newSound.name);
        }
        else
        {
            Debug.LogWarning("Attempted to set a null AudioSource.");
        }
    }


    }

    
