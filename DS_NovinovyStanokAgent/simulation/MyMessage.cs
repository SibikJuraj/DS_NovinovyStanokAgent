using OSPABA;
namespace simulation
{
	public class MyMessage : MessageForm
	{
		public double StartWaitingTime { get; set; }
		public MyMessage(Simulation sim) :
			base(sim)
		{
			StartWaitingTime = sim.CurrentTime;
		}

		public MyMessage(MyMessage original) :
			base(original)
		{
			// copy() is called in superclass
			StartWaitingTime = original.StartWaitingTime;
		}

		override public MessageForm CreateCopy()
		{
			return new MyMessage(this);
		}

		override protected void Copy(MessageForm message)
		{
			base.Copy(message);
			MyMessage original = (MyMessage)message;
			StartWaitingTime = original.StartWaitingTime;
			// Copy attributes
		}
	}
}
