using NUnit.Framework;

namespace MonopolySpecification
{
  [TestFixture]
  public class PlayerSpecification
  {
    private Player _player;
    
    [SetUp]
    public void SetUp()
    {
      _player = new Player(Resource.Andy);
    }

    [Test]
    public void Players_can_be_identified_by_name()
    {
      Assert.AreEqual(Resource.Andy, _player.Name);
    }

    [Test]
    public void Players_start_at_a_predefined_board_position()
    {
      Assert.AreEqual(Resource.StartPosition, _player.Position);
    }

    [Test]
    public void Players_start_with_a_fixed_amount_of_cash()
    {
      Assert.AreEqual(Resource.StartingCash, _player.Cash);
    }
  }
}
