using UnityEditor;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    public float range = 1f; // Distance � laquelle l'animation doit se d�clencher
    public GameObject targetObjet; // Objet qui d�clenche l'activation de l'animation

    private Animator myNPCAnimator;

    private void Start()
    {
        myNPCAnimator = GetComponent<Animator>(); // R�cup�re l'Animator du NPC
        myNPCAnimator.enabled = false; // D�sactive l'animation au d�part
    }

    private void Update()
    {
        // Calcule la distance entre le NPC et l'objet cible (joueur)
        float distance = Vector3.Distance(transform.position, targetObjet.transform.position);

        // Si la distance est inf�rieure � la "range", on active l'animation
        myNPCAnimator.enabled = distance <= range; // Active ou d�sactive l'animation selon la distance
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, range); // Affiche une zone de d�tection visuelle dans l'�diteur
    }
}
