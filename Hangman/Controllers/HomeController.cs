using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using HangmanGame.Models;

namespace HangmanGame.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index(string word)
    {
      Hangman hangman = new Hangman();
      return View(hangman);
    }

    [HttpGet("/game")]
    public ActionResult Game()
    {
      Hangman hangman = Hangman.GetHangMan()[0];
      return View(hangman);
    }

    [HttpPost("/guess")]
    public ActionResult Guess()
    {
      string guess = Request.Form["guess"];
      Hangman hangman = Hangman.GetHangMan()[0];
      hangman.AddGuess(guess);
      if(hangman.GetGuesses() <= 0)
      {
        Hangman.GetHangMan().Clear();
        return View("gameover");
      }
      return View("game", hangman);
    }
  }
}
