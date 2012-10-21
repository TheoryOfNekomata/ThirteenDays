#region Descriptions

#region File
/**
 * Name:			Powerup.cs
 * Description:		Source file for powerups.
 * Date Created:	‎2012 ‎October ‎21 - 11:51 [+8]
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
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace ThirteenDays.Elements {
	/// <summary>
	/// A <code>GameEntity</code> that can be picked up.
	/// </summary>
	abstract class Powerup : GameEntity {
		#region Fields


		bool isPickableByNPC;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets a Boolean value if this <code>Powerup</code> can be picked by
		/// NPCs (non-playable-characters).
		/// </summary>
		public bool IsPickableByNPC {
			get { return isPickableByNPC; }
			set { isPickableByNPC = value; }
		}


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>Powerup</code>.
		/// </summary>
		/// <param name="name">The <code>Powerup</code>'s name.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if <code>Powerup</code> can by picked by NPC.</param>
		public Powerup(string name = "", bool isPickableByNPC = false)
		: base(name) {
			IsPickableByNPC = isPickableByNPC;
		}


		/// <summary>
		/// Creates a new <code>Powerup</code> in the specified in-game location.
		/// </summary>
		/// <param name="name">The <code>Powerup</code>'s name.</param>
		/// <param name="location">The <code>Powerup</code>'s in-game location.</param>
		public Powerup(string name, Vector2 location)
		: base(name, location) { }


		/// <summary>
		/// Creates a new <code>Powerup</code> in the specified in-game location.
		/// </summary>
		/// <param name="name">The <code>Powerup</code>'s name.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if <code>Powerup</code> can by picked by NPC.</param>
		/// <param name="location">The <code>Powerup</code>'s in-game location.</param>
		public Powerup(string name, bool isPickableByNPC, Vector2 location)
		: base(name, location) {
			IsPickableByNPC = isPickableByNPC;
		}


		#endregion
	}


	/// <summary>
	/// A <code>Powerup</code> that adjusts attributes when picked.
	/// </summary>
	class AttributePowerup : Powerup {
		#region Fields


		Dictionary<AttributePowerupTarget, int> increment;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the increment of this <code>AttributePowerup</code>'s target.
		/// </summary>
		public Dictionary<AttributePowerupTarget, int> Increment {
			get { return increment; }
			set { increment = value; }
		}


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>AttributePowerup</code>.
		/// </summary>
		/// <param name="name">The <code>AttributePowerup</code>'s name.</param>
		/// <param name="increment">The increment to the value of <paramref name="target"/>.</param>
		/// <param name="target">The target attribute.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if <code>AttributePowerup</code> is pickable by NPCs.</param>
		public AttributePowerup(string name,
								int increment,
								AttributePowerupTarget target,
								bool isPickableByNPC = false)
			: base(name, isPickableByNPC) {
			if(target != AttributePowerupTarget.All)
				Increment[target] = increment;
			else
				foreach(AttributePowerupTarget _target in Enum.GetValues(typeof(AttributePowerupTarget)))
					Increment[_target] = increment;
		}


		/// <summary>
		/// Creates a new <code>AttributePowerup</code> using a mapping of increments to target attributes.
		/// </summary>
		/// <param name="name">The <code>AttributePowerup</code>'s name.</param>
		/// <param name="increments">Mapping of increments to target attributes.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if <code>AttributePowerup</code> is pickable by NPCs.</param>
		public AttributePowerup(string name,
								Dictionary<AttributePowerupTarget, int> increments,
								bool isPickableByNPC = false)
			: base(name, isPickableByNPC) {
			Increment = increments;
		}


		/// <summary>
		/// Creates a new <code>AttributePowerup</code> in the specified in-game location.
		/// </summary>
		/// <param name="name">The <code>AttributePowerup</code>'s name.</param>
		/// <param name="location">The entity's in-game location.</param>
		/// <param name="increment">The increment to the value of <paramref name="target"/>.</param>
		/// <param name="target">The target attribute.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if <code>AttributePowerup</code> is pickable by NPCs.</param>
		public AttributePowerup(string name,
								Vector2 location,
								int increment,
								AttributePowerupTarget target,
								bool isPickableByNPC = false)
			: this(name, increment, target, isPickableByNPC) {
			Location = location;
		}


		/// <summary>
		/// Creates a new <code>AttributePowerup</code> using a mapping of increments to target attributes.
		/// </summary>
		/// <param name="name">The <code>AttributePowerup</code>'s name.</param>
		/// <param name="location">The entity's in-game location.</param>
		/// <param name="increments">Mapping of increments to target attributes.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if <code>AttributePowerup</code> is pickable by NPCs.</param>
		public AttributePowerup(string name,
								Vector2 location,
								Dictionary<AttributePowerupTarget, int> increments,
								bool isPickableByNPC = false)
			: this(name, increments, isPickableByNPC) {
			Location = location;
		}


		#endregion
	}


	/// <summary>
	/// Target for an <code>AttributePowerup</code>.
	/// </summary>
	enum AttributePowerupTarget {
		/// <summary>
		/// The <code>AttributePowerup</code> applies on hit points.
		/// </summary>
		HitPoints,

		/// <summary>
		/// The <code>AttributePowerup</code> applies on memory points.
		/// </summary>
		MemoryPoints,

		/// <summary>
		/// The <code>AttributePowerup</code> applies on movement speed.
		/// </summary>
		Speed,

		/// <summary>
		/// The <code>AttributePowerup</code> applies on all attributes.
		/// </summary>
		All
	}


	/// <summary>
	/// A <code>Powerup</code> that provides a <code>Weapon</code>.
	/// </summary>
	class WeaponPowerup : Powerup {
		#region Fields

		Weapon weapon;

		#endregion

		#region Properties

		/// <summary>
		/// The <code>Weapon</code> corresponding the <code>WeaponPowerup</code>.
		/// </summary>
		public Weapon Weapon {
			get { return weapon; }
			set { weapon = value; }
		}

		#endregion

		#region Initializations

		/// <summary>
		/// Constructs a new <code>WeaponPowerup</code>.
		/// </summary>
		/// <param name="name">The <code>WeaponPowerup</code>'s name.</param>
		/// <param name="weapon">The <code>Weapon</code> that the <code>WeaponPowerup</code> corresponds to.</param>
		/// <param name="isPickableByNPC">Boolean value indicating if this <code>WeaponPowerup</code> can be picked by NPCs.</param>
		public WeaponPowerup(string name,
					  Weapon weapon,
					  bool isPickableByNPC = false)
		: base(name, isPickableByNPC) {
			Weapon = weapon;
		}

		#endregion
	}
}
