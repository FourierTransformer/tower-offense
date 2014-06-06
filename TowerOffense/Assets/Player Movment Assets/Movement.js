#pragma strict

public var speed = 5.0;

function Start () {

}

function Update () {
var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
transform.Translate(x,z,0);
}