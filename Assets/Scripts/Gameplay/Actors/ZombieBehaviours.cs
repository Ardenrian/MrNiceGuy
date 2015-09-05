using UnityEngine;
using System.Collections;


public abstract class ZombieBehaviour{
	public abstract Vector3 forceToAdd (Vector3 positionZombie, Vector3 positionNiceGuy, Vector3 speedZombie, Vector3 speedNiceGuy, float speed_, float speedup_);
}

public class FirstBehaviour: ZombieBehaviour{

	public FirstBehaviour(){}

	public override Vector3 forceToAdd(Vector3 positionZombie, Vector3 positionNiceGuy, Vector3 speedZombie, Vector3 speedNiceGuy, float speed_, float speedup_){
		Vector3 forcetoadd= new Vector3(0,0,0);
		if (Vector3.Distance (positionNiceGuy, positionZombie) > 1) {
			Vector3 direction= positionNiceGuy- positionZombie;
			forcetoadd= (Time.deltaTime*direction* (speed_ + speedup_*Time.time));
		}
		return forcetoadd;
	}

}