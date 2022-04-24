using OSPABA;
namespace simulation
{
	public class Sprava : MessageForm
	{
		public double StartWaitingTime { get; set; }
		public Sprava(Simulation sim) :
			base(sim)
		{
			StartWaitingTime = sim.CurrentTime;
		}

		public Sprava(Sprava original) :
			base(original)
		{
			// copy() is called in superclass
			StartWaitingTime = original.StartWaitingTime;
		}

		override public MessageForm CreateCopy()
		{
			return new Sprava(this);
		}

		override protected void Copy(MessageForm message)
		{
			base.Copy(message);
			Sprava original = (Sprava)message;
			StartWaitingTime = original.StartWaitingTime;
			// Copy attributes
		}
	}
}
