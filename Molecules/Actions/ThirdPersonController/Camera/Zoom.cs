using UnityEngine;
using UnityCamera = UnityEngine.Camera;
namespace Molecules.Actions.ThirdPersonController.Camera{
    using Molecules.Data;
    public class Zoom : MonoBehaviour{
        public new UnityCamera camera;
        public string inputName = "Fire2";
        public float targetFOV = 20f;
        public float speed = 15f;
        [HideInInspector] public float defaultFOV;
        public void Start(){
            if(!States.all.ContainsKey("Player/IsZooming")){
                States.all["Player/IsZooming"] = false;
            }
            this.defaultFOV = this.camera.fieldOfView;
        }
        public void Update(){
            var isZooming = States.all["Player/IsZooming"] = Input.GetAxisRaw(this.inputName) > 0;
            var destinationFOV = isZooming ? this.targetFOV : this.defaultFOV;
            if(this.camera.fieldOfView != destinationFOV){
                this.camera.fieldOfView = Mathf.MoveTowards(this.camera.fieldOfView,destinationFOV,Time.deltaTime * this.speed);
            }
        }
    }
}