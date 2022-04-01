using System;

namespace A6MinotaurLabyrinth
{
	// Represents something that the player can sense as they wander the labyrinth.
	public interface ISense
	{
		// Returns whether the player should be able to sense the thing in question.
		bool CanSense(LabyrinthGame game);

		// Displays the sensed information. (Assumes `CanSense` was called first and returned `true`.)
		void DisplaySense(LabyrinthGame game);
	}

	// Represents the player's ability to sense the light in the entrance room.
	public class LightInEntranceSense : ISense
	{
		// Returns `true` if the player is in the entrance room.
		public bool CanSense(LabyrinthGame game) => game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance;

		// Displays the appropriate message if the player can see the light from outside the labyrinth
		public void DisplaySense(LabyrinthGame game) => ConsoleHelper.WriteLine("You see light in this room coming from outside the labyrinth. This is the entrance.", ConsoleColor.Yellow);
	}

	// Represents the player's ability to sense the magic sword.
	public class SwordSense : ISense
	{
		// Returns `true` if the player is in the sword room.
		public bool CanSense(LabyrinthGame game) => game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Sword;

		// Displays the appropriate message depending on whether the sword is picked up or not.
		public void DisplaySense(LabyrinthGame game)
		{
			if (game.PlayerHasSword) ConsoleHelper.WriteLine("This is the sword room but you've already picked up the sword!", ConsoleColor.DarkCyan);
			else ConsoleHelper.WriteLine("You can sense that the sword is nearby!", ConsoleColor.DarkCyan);
		}
	}
}
