#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Atomic
{
	static class Program
	{
		private static Atom game;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ()
		{
			game = new Atom ();
			game.Run ();
		}
	}
}
