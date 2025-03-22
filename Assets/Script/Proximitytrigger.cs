using UnityEditor;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    public float range = 1f; // Distance à laquelle l'animation doit se déclencher
    public GameObject targetObjet; // Objet qui déclenche l'activation de l'animation

    private Animator myNPCAnimator;

    private void Start()
    {
        myNPCAnimator = GetComponent<Animator>(); // Récupère l'Animator du NPC
        myNPCAnimator.enabled = false; // Désactive l'animation au départ
    }

    private void Update()
    {
        // Calcule la distance entre le NPC et l'objet cible (joueur)
        float distance = Vector3.Distance(transform.position, targetObjet.transform.position);

        // Si la distance est inférieure à la "range", on active l'animation
        myNPCAnimator.enabled = distance <= range; // Active ou désactive l'animation selon la distance
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, range); // Affiche une zone de détection visuelle dans l'éditeur
    }
}
