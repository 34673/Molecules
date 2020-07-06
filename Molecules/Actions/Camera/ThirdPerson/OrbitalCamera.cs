using UnityEngine;
namespace Molecules.Actions.Camera.ThirdPerson{
	using Molecules.Data;
	public class OrbitalCamera : MonoBehaviour{
		public Transform pivot;
		public Transform target;
		public string horizontalInput = "Mouse X";
		public string verticalInput = "Mouse Y";
		public Vector2 verticalClamps = new Vector2(-89f,89f);
		public void Start(){
            if(!States.all.ContainsKey("Player/IsZooming")){
                States.all["Player/IsZooming"] = false;
            }
        }
		public void Update(){
			var horizontalInput = Input.GetAxisRaw(this.horizontalInput);
			var verticalInput = Input.GetAxisRaw(this.verticalInput);
			var input = new Vector2(horizontalInput,verticalInput);
			if(input != Vector2.zero){
				input = States.all["Player/IsZooming"] ? input / 3 : input;
				var currentRotation = this.pivot.rotation.eulerAngles;
				var correctedVertical = currentRotation.x - input.y;
				if(correctedVertical > 180f){
					correctedVertical -= 360;
				}
				correctedVertical = Mathf.Clamp(correctedVertical,this.verticalClamps.x,this.verticalClamps.y);
				this.pivot.rotation = Quaternion.Euler(correctedVertical,currentRotation.y + input.x,0f);
			}
			this.pivot.position = this.target.position;
		}
	}
}