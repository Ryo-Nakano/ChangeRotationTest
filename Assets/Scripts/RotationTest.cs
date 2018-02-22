using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationTest : MonoBehaviour {

	Quaternion rotation1;
	Quaternion rotation2;

	float step;
	[SerializeField] float rotationSpeed;

	bool isFaceUp = true;//反重力状態かどうか判定するフラグ

	[SerializeField] Text playerStateText;


	// Use this for initialization
	void Start () {
		rotation1 = Quaternion.Euler (0, 0, 0);
		rotation2 = Quaternion.Euler (0, 0, 180);
	}
	
	// Update is called once per frame
	void Update () {
		RotationControll ();//GameObjectの回転をコントロールする関数
	}

	//GameObjectの回転をコントロールする関数
	void RotationControll()
	{
		step = rotationSpeed * Time.deltaTime;

		if (isFaceUp == false) 
		{
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, rotation2, step);
		}
		else//isAntiGravity == trueの時
		{
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, rotation1, step);
		}

		//spaceボタン押した時
		if(Input.GetKeyDown("space"))
		{
			if (isFaceUp == true) {
				isFaceUp = false;
				playerStateText.text = "FaceDown";
			} 
			else//isAntiGravity == falseの時
			{
				isFaceUp = true;
				playerStateText.text = "FaceUp";
			}
		}
	}
}
