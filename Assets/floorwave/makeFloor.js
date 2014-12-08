#pragma strict


// cube prefab
var prefabCube : Transform;


function Start () {

   var x : float;
   var z : float;

   // build floor with cubes
   for(x=-19.5; x<=19.5; x+=1) {
      for(z=-19.5; z<=19.5; z+=1) {
         Instantiate(prefabCube, Vector3(x, 0, z), Quaternion.identity);
      }
   }
}