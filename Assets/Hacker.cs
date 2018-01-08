using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "sugar", "pastries", "milk", "cream", "frappucino" };
    string[] level2Passwords = { "classroom", "faculty", "auditorium", "cafeteria","computer"
};
    string[] level3Passwords = { "laboratory", "emergency", "antibiotic", "surgery", "wheelchair" };

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("M1T17");
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the coffee shop.");
        Terminal.WriteLine("Press 2 for the school.");
        Terminal.WriteLine("Press 3 for Hospital.");
        Terminal.WriteLine("\nEnter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (input.Equals("007"))
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("\nWelcome Mr. Bond!\nType 'menu' and choose a level.");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            Terminal.ClearScreen();
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input.Equals("1"))
        {
            level = 1;
            StartGame();
        }
        else if (input.Equals("2"))
        {
            level = 2;
            StartGame();
        }
        else if (input.Equals("3"))
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
       
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("INVALID!");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayScreen();
        }
        else
        {
            StartGame();
        }
    }

    void DisplayScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
       
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You have access the coffee shop!");
                Terminal.WriteLine(@"
  ;)( ;
 :----:     o8Oo./
C|====| ._o8o8o8Oo_.
 |    |  \========/
 `----'   `------'           
    "
                );
                break;
            case 2:
                Terminal.WriteLine("You have access to the school files");
             
                Terminal.WriteLine(@"
                  __________
         _______/__        /
        /         /       /
       / SCHOOOL /       /
      / RECORDS /       /
     /         /______ /
    /_________/
        "
                );
                break;
            case 3:
                Terminal.WriteLine(@"
  .-.    __
 |   |  /\ \
 |   |  \_\/      __        .-.
 |___|        __ /\ \      /:::\
 |:::|       / /\\_\/     /::::/
 |:::|       \/_/        / `-:/
 ':::'__   _____ _____  /    /
     / /\ /     |:::::\ \   /
     \/_/ \     |:::::/  `""
            """"""""""
  "
                );
                Terminal.WriteLine("You have access the hospital medicines");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
