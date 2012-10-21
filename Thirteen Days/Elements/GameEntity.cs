#region Descriptions

#region File
/**
 * Name:			GameEntity.cs
 * Description:		Source file for the <code>GameEntity</code> class, the generic entities in the game.
 * Date Created:	‎2012 ‎October ‎21 - 04:49 [+8]
 */
#endregion

#region Author
/**
 * Name:			Temoto-kun
 * E-mail Address:	kiiroifuriku@hotmail.com
 * Website:			http://nihilist-philanthropy.co.cc
 */
#endregion

#region Team
/**
 * Name:			theShrine
 * E-mail Address:	N/A
 * Website:			http://shrine.nihilist-philanthropy.co.cc
 */
#endregion

#region Project
/**
 * Name:			Thirteen Days
 * Genre:			Platformer, Shmup, RPG, Puzzle
 */
#endregion

#endregion

#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace ThirteenDays.Elements {
	/// <summary>
	/// Generic game entity.
	/// </summary>
	abstract class GameEntity {
		#region Fields


		string name;
		Vector2 location;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the name of this <code>GameEntity</code>.
		/// </summary>
		public string Name {
			get { return name; }
			set { name = value; }
		}


		/// <summary>
		/// Gets or sets the in-game location of this <code>GameEntity</code>.
		/// </summary>
		public Vector2 Location {
			get { return location; }
			set { location = value; }
		}


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>GameEntity</code>.
		/// </summary>
		/// <param name="name">The name of the <code>GameEntity</code>.</param>
		public GameEntity(string name = "") {
			Name = name;
			Location = new Vector2(-1);
		}


		/// <summary>
		/// Creates a new <code>GameEntity</code> in the specified in-game location.
		/// </summary>
		/// <param name="name">The name of the <code>GameEntity</code>.</param>
		/// <param name="location">The in-game location of the <code>GameEntity</code>.</param>
		public GameEntity(string name, Vector2 location)
			: this(name) {
			Name = name;
			Location = location;
		}


		#endregion
	}
}
