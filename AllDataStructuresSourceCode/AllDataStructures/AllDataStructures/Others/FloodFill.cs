using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.Others
{
	
	// Flood fill
	public class FloodFill
	{

		// Dimentsions of  screen 
		public int M = 4;
		public int N = 4;

		
		public void floodFillUtil(int[,] screen,
								int x, int y,
								int prevC, int newC)
		{
			// Screen is handled
			//what happens when it goes out of screen
			if (x < 0 || x >= M ||
				y < 0 || y >= N)
				return;

			if (screen[x, y] != prevC)
				return;

			// Replace the color at (x, y) 
			screen[x, y] = newC;

			// Recur for north, east, south and west 
			floodFillUtil(screen, x + 1, y, prevC, newC);
			floodFillUtil(screen, x - 1, y, prevC, newC);
			floodFillUtil(screen, x, y + 1, prevC, newC);
			floodFillUtil(screen, x, y - 1, prevC, newC);
		}

		public void floodFill(int[,] screen, int x,
							int y, int newC)
		{
			int prevC = screen[x, y];
			floodFillUtil(screen, x, y, prevC, newC);
		}

		// Driver code 
		public  void Start()
		{
			int[,] screen = 
					{{1, 1, 1, 1},
					{1, 1, 1, 2},
					{1, 2, 2, 1},
					{1, 2, 2, 2}
					};
			int x = 2, y = 2, newC = 3;
			for (int i = 0; i < M; i++)
			{
				for (int j = 0; j < N; j++)
					Console.Write(screen[i, j] + " ");
				Console.WriteLine();
			}
			floodFill(screen, x, y, newC);

			Console.WriteLine("Updated screen after" +
							"call to floodFill: ");
			for (int i = 0; i < M; i++)
			{
				for (int j = 0; j < N; j++)
					Console.Write(screen[i, j] + " ");
				Console.WriteLine();
			}
		}
	}


}
