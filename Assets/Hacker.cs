using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class Hacker : MonoBehaviour
{
//	GameLevel;
	int level;
	enum Screen
	{
		MainMenu, Password, Win
	}
	private Screen currentScreen;
	
	// Use this for initialization
	void Start ()
	{
		ShowMainMenu();
	}

	void ShowMainMenu()
	{
		Terminal.ClearScreen();
		Terminal.WriteLine("Highridge Drive Anagram Game");
		Terminal.WriteLine("----------------------------\n");
		Terminal.WriteLine("Where to find words in ()");
		Terminal.WriteLine("- Press 1 for Easy (house)");
		Terminal.WriteLine("- Press 2 for Medium (pasture)");
		Terminal.WriteLine("- Press 3 for Hard (Highridge)");
		Terminal.WriteLine("- Press X to exit game\n");
		Terminal.WriteLine("Thanks for playing!");
	}

	void OnUserInput(string input)
	{
		if (input == "menu")
		{
			currentScreen = Screen.MainMenu;
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);	
		}
	}

	private void RunMainMenu(string input)
	{
		switch (input)
		{
			case "1":
				level = 1;
				ShowGameLevel(level);
				break;
			case "2":
				level = 2;
				ShowGameLevel(level);
				break;
			case "3":
				level = 3;
				ShowGameLevel(level);
				break;
			default:
				currentScreen = Screen.MainMenu;
				ShowMainMenu();
				break;
		}
	}

	void ShowGameLevel(int inputLevel)
	{
		currentScreen = Screen.Password;
		Terminal.WriteLine("You chose level " + inputLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
