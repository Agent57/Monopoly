using System;
using NUnit.Framework;

namespace MonopolySpecification
{
  [TestFixture]
  public class GameSpecification
  {
    private Game _game;
    private Player _andy;
    private Player _betty;

    [SetUp]
    public void SetUp()
    {
      _game = new Game();
      _andy = new Player(Resource.Andy);
      _betty = new Player(Resource.Betty);
    }

    [Test]
    [ExpectedException(typeof(InvalidOperationException),
      ExpectedMessage = "The game can't start with less than 2 players")]
    public void A_game_cant_start_with_less_than_2_players()
    {
      StartTheGameWith(_andy);
      Assert.Fail("InvalidOperationException was expected");
    }

    [Test]
    public void A_game_needs_at_least_2_players_to_start()
    {
      StartTheGameWith(_andy, _betty);
      Assert.IsTrue(_game.PlayerCount >= Resource.MinimumPlayerCount);
    }

    [Test]
    public void The_first_player_added_will_take_the_first_turn()
    {
      StartTheGameWith(_andy, _betty);
      Assert.IsTrue(_game.NextPlayer() == _andy);
    }

    [Test]
    public void Each_player_will_take_their_turn_in_the_order_they_were_added()
    {
      StartTheGameWith(_andy, _betty);
      SkipTurns(1);
      Assert.IsTrue(_game.NextPlayer() == _betty);
    }

    [Test]
    public void Once_each_player_has_had_a_turn_the_first_player_goes_again()
    {
      StartTheGameWith(_andy, _betty);
      SkipTurns(2);
      Assert.IsTrue(_game.NextPlayer() == _andy);
    }

    private void StartTheGameWith(params Player[] players)
    {
      foreach (var player in players)
        _game.AddPlayer(player);

      _game.Start();
    }

    private void SkipTurns(int count)
    {
      while (count-- > 0)
        _game.NextPlayer();
    }
  }
}