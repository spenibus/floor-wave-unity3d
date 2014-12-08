using UnityEngine;
using System.Collections;

public class floorwave_cube : MonoBehaviour {


   GameObject antagonist;
   float startHeight;
   float maxHeight = 4f;

   float antagonistDistanceReactionMin = 0f;
   float antagonistDistanceReactionMax = 5f;
   float antagonistRange;




   void Awake() {

   } // end Awake()




   void Start() {

      antagonist = GameObject.Find("antagonist");

      startHeight = transform.position.y;

      antagonistDistanceReactionMin += antagonist.transform.position.y * 1.2f;
      antagonistDistanceReactionMax += antagonist.transform.position.y * 1.2f;

      antagonistRange = antagonistDistanceReactionMax - antagonistDistanceReactionMin;

   } // end Start()




   void Update() {

      // reset position
      transform.position = new Vector3(
         transform.position.x,
         startHeight,
         transform.position.z
      );


      // check distance to antagonist
      float proximity = Vector3.Distance(antagonist.transform.position, transform.position);

      float yPos = startHeight;

      if(proximity <= antagonistDistanceReactionMin) {
         yPos += maxHeight;
      }
      else if(proximity <= antagonistDistanceReactionMax) {
         yPos += maxHeight - (
            maxHeight
            / (antagonistDistanceReactionMax - antagonistDistanceReactionMin)
            * (proximity - antagonistDistanceReactionMin)
         );
      }

      // change height
      if(yPos != transform.position.y) {
         transform.position = new Vector3(
            transform.position.x,
            yPos,
            transform.position.z
         );
      }

   } // end Update()




   void FixedUpdate() {

   } // end FixedUpdate()




   void OnGUI() {

   } // end OnGUI()
}