using UnityEngine;

public class NPCMusicTrigger : MonoBehaviour
{
    public float range = 5f; // Distance d'activation
    public GameObject player; // R�f�rence au joueur
    private AudioSource musicSource;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true; // Pour que la musique tourne en boucle
        musicSource.playOnAwake = false; // �vite qu'elle commence toute seule
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= range && !musicSource.isPlaying)
        {
            musicSource.Play(); // Joue la musique si le joueur est proche
        }
        else if (distance > range && musicSource.isPlaying)
        {
            musicSource.Stop(); // Arr�te la musique si le joueur s��loigne
        }
    }
}

