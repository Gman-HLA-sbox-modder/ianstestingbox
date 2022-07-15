using Sandbox;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Spawnable]
[Library( "npc_wandertest", Title = "Wander" )]
public partial class Wandertest : NPC
{
	public override float SpawnHealth => 100;

	public override bool HaveDress => false;

	// public NavSteer Steer;

	public override void Spawn()
	{
		base.Spawn();

		SetModel("models/scientist/scientist.vmdl");

		SetBodyGroup(1, Rand.Int(0, 3));

		var wander = new Sandbox.Nav.Wander();
		Steer = wander;
	}
}
