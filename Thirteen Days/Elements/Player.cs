#region Descriptions

#region File
/**
 * Name:			Player.cs
 * Description:		Source file for the <code>Player</code> class.
 * Date Created:	‎2012 ‎October ‎21 - 03:27 [+8]
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
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
#endregion

namespace ThirteenDays.Elements {
	/// <summary>
	/// Entity that is controlled by the user.
	/// </summary>
	class Player : GameEntity {
		#region Fields


		bool isMale;

		byte hitPoints;
		byte memoryPoints;

		List<Weapon> weapons = new List<Weapon>();

		Weapon primaryWield;
		Weapon secondaryWield;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the Boolean value that determines if the <code>Player</code> is a male.
		/// </summary>
		public bool IsMale {
			get { return isMale; }
			set { isMale = value; }
		}


		/// <summary>
		/// Gets or sets the <code>Player</code>'s current hit points.
		/// </summary>
		public byte HitPoints {
			get { return hitPoints; }
			set { hitPoints = value; }
		}


		/// <summary>
		/// Gets or sets the <code>Player</code>'s current memory points.
		/// </summary>
		public byte MemoryPoints {
			get { return memoryPoints; }
			set { memoryPoints = value; }
		}


		/// <summary>
		/// Gets or sets the <code>Player</code>'s list of acquired <code>Weapon</code>s.
		/// </summary>
		public List<Weapon> Weapons {
			get { return weapons; }
			set { weapons = value; }
		}


		/// <summary>
		/// Gets or sets the <code>Player</code>'s <code>Weapon</code> for primary wield.
		/// </summary>
		public Weapon PrimaryWield {
			get { return primaryWield; }
			set { primaryWield = value; }
		}


		/// <summary>
		/// Gets or sets the <code>Player</code>'s <code>Weapon</code> for secondary wield.
		/// </summary>
		public Weapon SecondaryWield {
			get { return secondaryWield; }
			set { secondaryWield = value; }
		}


		#endregion

		#region Events


		// TODO [006]: We need event handlers for HP and MP change.
		public event EventHandler<EventArgs> HitPointsChanged;

		protected internal void OnHitPointChange() {
			if(HitPointsChanged != null)
				HitPointsChanged(this, new EventArgs());
		}

		public event EventHandler<EventArgs> MemoryPointsChanged;

		protected internal void OnMemoryPointChange() {
			if(MemoryPointsChanged != null)
				MemoryPointsChanged(this, new EventArgs());
		}
		// TODO [007]: We need event handlers for Primary and secondary wields.


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>Player</code>.
		/// </summary>
		/// <param name="name">The <code>Player</code>'s name.</param>
		/// <param name="isMale">Is <code>Player</code> a male?</param>
		/// <param name="hitPoints">The <code>Player</code>'s hit points.</param>
		/// <param name="memoryPoints">The <code>Player</code>'s memory points.</param>
		/// <param name="weapons">The <code>Player</code>'s acquired weapons.</param>
		/// <param name="primaryWield">The <code>Player</code>'s <code>Weapon</code> for primary wield.</param>
		/// <param name="secondaryWield">The <code>Player</code>'s <code>Weapon</code> for secondary wield.</param>
		public Player(string name,
					  bool isMale,
					  byte hitPoints = 100,
					  byte memoryPoints = 0,
					  List<Weapon> weapons = null,
					  Weapon primaryWield = null,
					  Weapon secondaryWield = null) : base(name) {
			Name = name;
			IsMale = isMale;
			HitPoints = hitPoints;
			MemoryPoints = memoryPoints;
			Weapons = weapons;
			PrimaryWield = primaryWield;
			SecondaryWield = secondaryWield;
		}

		/// <summary>
		/// Creates a new <code>Player</code> at a specific location.
		/// </summary>
		/// <param name="name">The <code>Player</code>'s name.</param>
		/// <param name="isMale">Is <code>Player</code> a male?</param>
		/// <param name="location">The <code>Player</code>'s in-game location.</param>
		/// <param name="hitPoints">The <code>Player</code>'s hit points.</param>
		/// <param name="memoryPoints">The <code>Player</code>'s memory points.</param>
		/// <param name="weapons">The <code>Player</code>'s acquired weapons.</param>
		/// <param name="primaryWield">The <code>Player</code>'s <code>Weapon</code> for primary wield.</param>
		/// <param name="secondaryWield">The <code>Player</code>'s <code>Weapon</code> for secondary wield.</param>
		public Player(string name,
					  bool isMale,
					  Vector2 location,
					  byte hitPoints = 100,
					  byte memoryPoints = 0,
					  List<Weapon> weapons = null,
					  Weapon primaryWield = null,
					  Weapon secondaryWield = null)
			: base(name, location) {
			Name = name;
			IsMale = isMale;
			Location = location;
			HitPoints = hitPoints;
			MemoryPoints = memoryPoints;
			Weapons = weapons;
			PrimaryWield = primaryWield;
			SecondaryWield = secondaryWield;
		}


		#endregion
	}
}
