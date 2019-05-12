using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class ForceFieldControl:MonoBehaviour 
                {

	public Collider2D forceFieldCollider; 
public ParticleSystem forceFieldParticle; 

	public void DeactivateField()
{

forceFieldCollider.enabled = false; 
forceFieldParticle.Stop(); 
}
}
