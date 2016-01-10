using UnityEngine;
using System.Collections;

public class PotassiumThinksControl : MonoBehaviour {

	private string name = "Potassium";
	private int age = 0;
	private int[] birthDate = {2016, 1, 10};
	private string gender = "female";
	private string astrologySign = "Capricornus";

	// Constructor
	PotassiumThinksControl()
	{

	}

	string getName()
	{
		return name;
	}
	void setName(string newName)
	{
		name = newName;
	}

	int getAge()
	{
		return age;
	}
	void setAge(int newAge)
	{
		age = newAge;
	}
}
