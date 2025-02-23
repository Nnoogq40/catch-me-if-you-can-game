using UnityEngine;

public class sound : MonoBehaviour
{
    AudioSource fuenteAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OntriggerEnter()
    {
        fuenteAudio.Play();
        
    }
    void OntriggerExit() {
        fuenteAudio.Stop();
    
    }
}
