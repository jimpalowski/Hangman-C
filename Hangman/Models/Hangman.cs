using System;
using System.Collections.Generic;

namespace HangmanGame.Models
{
  public class Hangman
  {
    private int _guessesRemaining;
    private int _random;
    private string _givenWord;
    private List<string> _wordMatched = new List<string> {};
    private List<string> _wordPool = new List<string> {"bubble", "coding", "bootcamp", "confused"};
    private List<string> _formerGuesses = new List<string> {};
    private static List<Hangman> _myHangmen = new List<Hangman> {};


    public Hangman()
    {
      _guessesRemaining = 6;
      Random RNG = new Random();
      _random = RNG.Next(_wordPool.Count);
      _givenWord = _wordPool[_random];
      _myHangmen.Add(this);

      foreach(var letter in _givenWord)
      {
        _wordMatched.Add("__");
      }
    }

    public string GetWord()
    {
      return _givenWord;
    }

    public int GetGuesses()
    {
      return _guessesRemaining;
    }
    public List<string> GetWordMatched()
    {
      return _wordMatched;
    }
    public List<string> FormerGuesses()
    {
      return _formerGuesses;
    }
    public void AddGuess(string character)
    {
      if(_formerGuesses.Contains(character))
      {
        Console.WriteLine("You've already guessed that letter!");
      }
      else
      {
        if(_givenWord.Contains((character)))
        {
          Console.WriteLine("You got the correct letter!");
          _formerGuesses.Add(character);
        }
        else
        {
          Console.WriteLine("Idiot!");
          _formerGuesses.Add(character);
          _guessesRemaining--;
        }
      }
    }

    public static List<Hangman> GetHangMan()
    {
      return _myHangmen;
    }
  }
}
