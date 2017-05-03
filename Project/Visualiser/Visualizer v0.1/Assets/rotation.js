#pragma strict

var speed: float = 15.0;

function Start () {
	
}
 
function Update()
{
    transform.Rotate(0, speed * Time.deltaTime, 0);
}