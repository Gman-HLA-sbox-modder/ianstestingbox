using Sandbox;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Spawnable]
[Library( "npc_scientist", Title = "HL1 Scientist" )]
public partial class Scientist : NPC
{
	public override float SpawnHealth => 100;

	public override bool HaveDress => false;

	private bool IsScared;

	private TimeSince TimeSinceLastIBAttempt;
	private TimeSince TimeSinceFirstScared;

	private TimeSince TimeSinceStartedHeal;

	private Vector3 LastPosition {get; set;}

	// public NavSteer Steer;

	public override void Spawn()
	{
		base.Spawn();

		SetModel("models/scientist/scientist.vmdl");

		SetBodyGroup(1, Rand.Int(0, 3));

		var wander = new Sandbox.Nav.Wander();
		Steer = wander;
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );

		IsScared = true;
		TimeSinceFirstScared = 0;

		if (Rand.Int(1, 2) == 1)
		{
			PlaySound("scientist.hurt");
		}
	}

	public override void Tick()
	{
		base.Tick();

		// Log.Info("Sim");

		if (IsScared) 
		{
			SetAnimParameter("b_isscared", true);
		}
		
		if (IsScared && TimeSinceFirstScared >= 50.0f) 
		{
			SetAnimParameter("b_isscared", false);
		}

		var randInt = Rand.Int(1, 5);

		if (TimeSinceLastIBAttempt > 5.0f)
		{
			if (randInt == 1) 
			{
				SetAnimParameter("b_idlebreaker", true);

				TimeSinceLastIBAttempt = 0;
			} else if (randInt != 1)
			{
				TimeSinceLastIBAttempt = 0;
			}
		}

		// var entInSphere = FindInSphere(Position, 50);

		// DebugOverlay.Sphere(Position, 100, Color.Green);

		// foreach (var entity in entInSphere)
		// {
		// 	if (entity is SandboxPlayer player) 
		// 	{
		// 		if (player.Health < 100) 
		// 		{
		// 			Steer = new NavSteer();
		// 			Steer.Target = player.Position;

		// 			if (Velocity == 0 && player.Velocity == 0)
		// 			{
		// 				HealPlayer(player);	

		// 				if (TimeSinceStartedHeal >= 2.5f) 
		// 				{
		// 					player.Health += 25;
		// 				}

		// 				if (TimeSinceStartedHeal >= 7.0f) 
		// 				{
		// 					Steer = new Sandbox.Nav.Wander();
		// 				}
		// 			}
		// 		}
		// 	} else 
		// 	{
		// 		Steer = new Sandbox.Nav.Wander();
		// 	}
		// }
	}

	// private void HealPlayer(SandboxPlayer player) 
	// {
	// 	if (player.LifeState != LifeState.Alive) return;

	// 	TimeSinceStartedHeal = 0;

	// 	Steer = null;

	// 	SetAnimParameter("b_heal", true);
	// }

	public override void OnKilled() 
	{
		base.OnKilled();

		LastPosition = Position;

		Sound.FromWorld("scientist.death", LastPosition);
	}
}
