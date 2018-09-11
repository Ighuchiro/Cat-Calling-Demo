using UnityEngine;

public class playermovement : MonoBehaviour
{

	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
		var turn = Input.GetAxis("Mouse X") * 1.0f;


		transform.Translate(x, 0, 0);
		transform.Translate(0, 0, z);
		transform.Rotate (0, turn, 0);
	}
}
