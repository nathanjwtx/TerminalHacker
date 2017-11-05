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
	private const string Level1 = "goat";
	private const string Level2 = "donkey";


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
		else if (currentScreen == Screen.Password)
		{
			PasswordCheck(input);
		}
	}

	private void RunMainMenu(string input)
	{
		switch (input)
		{
			case "1":
				level = 1;
				StartGame(level);
				break;
			case "2":
				level = 2;
				StartGame(level);
				break;
//			case "3":
//				level = 3;
//				ShowGameLevel(level);
//				break;
		}
	}

	void StartGame(int inputLevel)
	{
		currentScreen = Screen.Password;
		Terminal.WriteLine("Enter password " + inputLevel);
	}

	void PasswordCheck(string input)
	{
		if (level == 1 && input == Level1)
		{
			Terminal.WriteLine("Welcome to Level 1");
		}
		else if (level == 2 && input == Level2)
		{
			Terminal.WriteLine("Welcome to Level 2");
		}
		else
		{
			Terminal.WriteLine("Incorrect password for level " + level);
			Terminal.WriteLine("Try again or enter 'menu' to go to Main Menu");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
