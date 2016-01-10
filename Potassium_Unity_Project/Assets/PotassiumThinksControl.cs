using UnityEngine;
using System.Collections;

public class PotassiumThinksControl {

	string name = "Potassium";
	int age = 0;
	byte[] birthDate = {2016, 1, 10};
	string gender = "female";
	string astrologySign = "Capricornus";

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
