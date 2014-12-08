using UnityEngine;
using System.Collections;

public class antagonist : MonoBehaviour {

   GameObject protagonist;

   bool isMoving = false;

   float spd = 10f; // per sec

   float xPosMin = -30f;
   float xPosMax =  30f;
   float zPosMin = -30f;
   float zPosMax =  30f;

   Vector3 newPos;




   void Start() {

      protagonist = GameObject.Find("protagonist");

      newPos = transform.position;
   } // end Start()




   void Update() {

      Screen.lockCursor = true;


      // set new destination
      if(transform.position == newPos) {

         newPos = new Vector3(
            Random.Range(xPosMin, xPosMax),
            0,
            Random.Range(zPosMin, zPosMax)
         );
      }


      // move to destination
      transform.position = Vector3.MoveTowards(
         transform.position,
         newPos,
         spd * Time.deltaTime
      );


      // change light color based on protagonist proximity
      float proximity = Vector3.Distance(protagonist.transform.position, transform.position);
      float proximityFactor = 1 - proximity/20;

      if(proximityFactor >= 0 && proximityFactor <= 1) {
         Color newColor = Color.Lerp(Color.white, Color.red, proximityFactor);
         Light[] lights = transform.gameObject.GetComponentsInChildren<Light>(true);
         foreach(Light li in lights) {
            li.color = newColor;
         }
      }



/*

*/




   } // end Update()




   void FixedUpdate() {

   } // end FixedUpdate()




   void OnGUI() {

   } // end OnGUI()
}