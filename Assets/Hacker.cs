using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class Hacker : MonoBehaviour
{
	// Game config data
	private string[] Level1Passwords = { "table", "blanket", "chair", "window", "pizza"};
	private string[] Level2Passwords = { "barn", "donkey", "creek", "garage", "snake", "turtle"};
	private string _levelPass;
	
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
		else if (currentScreen == Screen.Password)
		{
			PasswordCheck(input);
		}
	}

	private void RunMainMenu(string input)
	{
		bool isValidLevel = (input == "1" || input == "2");
		if (isValidLevel)
		{
			level = int.Parse(input);
			StartGame(level);
		}
		else
		{
			Terminal.WriteLine("Enter a valid level");
		}
	}

	void StartGame(int inputLevel)
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		switch (level)
		{
				case 1:
					_levelPass = Level1Passwords[2];
					break;
				case 2:
					_levelPass = Level2Passwords[3];
					break;
				default:
					Debug.LogError("Ooops!");
					break;
		}
		Terminal.WriteLine("Enter password " + inputLevel);
	}

	void PasswordCheck(string input)
	{
		if (input == _levelPass)
		{
			Terminal.WriteLine("Welcome to Level " + level);
		}
		else
		{
			Terminal.WriteLine("Incorrect password for level " + level);
			Terminal.WriteLine("Try again or enter 'menu' \nto go to Main Menu");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
