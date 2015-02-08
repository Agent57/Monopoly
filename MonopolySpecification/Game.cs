using System;
using System.Collections.Generic;

namespace MonopolySpecification
{
  public class Game
  {
    private readonly List<Player> _player = new List<Player>();
    private int _next;
    public int PlayerCount { get { return _player.Count; } }

    public void AddPlayer(Player player)
    {
      _player.Add(player);
    }

    public void Start()
    {
      if (PlayerCount < Resource.MinimumPlayerCount)
        throw new InvalidOperationException("The game can't start with less than 2 players");
    }

    public Player NextPlayer()
    {
      var whosTurn = _player[_next++];
      if (_next == PlayerCount)
        _next = 0;

      return whosTurn;
    }
  }
}