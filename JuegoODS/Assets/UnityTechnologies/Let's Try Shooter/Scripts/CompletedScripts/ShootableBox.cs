using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;
    // Reference to the particle system
    public ParticleSystem destructionParticles;

    public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
            // Activate the particle system
            if (destructionParticles != null)
            {
                // Instantiate the particle system at the object's position and rotation
                ParticleSystem instantiatedParticles = Instantiate(destructionParticles, transform.position, transform.rotation);
                instantiatedParticles.Play();

                // Optionally, destroy the particle system after it has played
                Destroy(instantiatedParticles.gameObject, instantiatedParticles.main.duration);
            }
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive (false);
		}
	}
}
