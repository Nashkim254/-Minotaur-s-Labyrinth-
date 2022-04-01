namespace A6MinotaurLabyrinth
{
	public static class LabyrinthCreator
	{
		RandomStartPoint myMaze=new RandomStartPoint();
		static readonly (int rows, int cols) smallCoords = (4, 4);
		static readonly (int rows, int cols) medCoords = (6, 6);
		static readonly (int rows, int cols) largeCoords = (8, 8);

		// Creates a small 4x4 game.
		public static LabyrinthGame CreateSmallGame()
		{
			(Map map, Location start) = InitializeMap(Size.Small);
			return CreateGame(map, start);
		}

		// Creates a medium 6x6 game.
		public static LabyrinthGame CreateMediumGame()
		{
			(Map map, Location start) = InitializeMap(Size.Medium);
			return CreateGame(map, start);
		}

		// Creates a large 8x8 game.
		public static LabyrinthGame CreateLargeGame()
		{
			(Map map, Location start) = InitializeMap(Size.Large);
			return CreateGame(map, start);
		}
		
		// Helper function that initializes the map size and all the map locations
		// Returns the initialized map and the entrance location (start) so we can
		// set the player starting location accordingly.
		private static (Map, Location) InitializeMap(Size mapSize)
		{
			Map map = mapSize switch
			{
				Size.Small => new Map(smallCoords.rows, smallCoords.cols),
				Size.Medium => new Map(medCoords.rows, medCoords.cols),
				Size.Large => new Map(largeCoords.rows, largeCoords.cols),
			};
			Location start = RandomizeMap(map);
			return (map, start);
		}

		// Creates a map with randomly placed and non-overlapping features
		// The Entrance will be located in a random position along the edge of the map
		// The Sword will be placed randomly in the map but it will not be adjacent to the Entrance
		// Traps & Monsters will be placed randomly
		private static Location RandomizeMap(Map map)
		{
			Location start = new Location(0, 0);
			map.SetRoomTypeAtLocation(start, RoomType.Entrance);
			map.SetRoomTypeAtLocation(new Location(2, 2), RoomType.Sword);
			return start;
		}

		private static Player InitializePlayer(Location start)
		{
			return new Player(start);
		}

		private static Monster[] InitializeMonsters(Map map)
		{
			// Ensure monster locations do not overlap existing locations on the map
			return new Monster[] { };
		}

		private static LabyrinthGame CreateGame(Map map, Location start)
		{
			Player player = InitializePlayer(start);
			Monster[] monsters = InitializeMonsters(map);
			return new LabyrinthGame(map, player, monsters);
		}

		private enum Size { Small, Medium, Large };
	}

}
