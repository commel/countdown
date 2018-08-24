using System;
using System.Threading;

namespace Example
{
	public struct MyData
	{
		public string Name;
	}

	public class App
	{
		public delegate int CalculatorMethod(int a, int b);

		static void Main(string[] args)
		{
			Countdown c = new Countdown(10);
			c.AtTheEndEvents += ItsOver;

			c.myAction = SayHello;

			CalculatorMethod cm_add = c.Add;
			CalculatorMethod cm_multi = Multiply;

			int a = 5;
			int b = 7;
			Console.WriteLine("Adding {0}+{1}={2}", a, b, cm_add(a, b));
			Console.WriteLine("Multiplying {0}+{1}={2}", a, b, cm_multi(a, b));

			while(c.counter > 0)
			{
				c.Decrement();
				Console.WriteLine("counter is at {0}.", c.counter);
				Thread.Sleep(1000);
			}
		}

 		public static void ItsOver(object sender, EventArgs e)
		{
			Console.WriteLine("IT IS OVER!");
			System.Environment.Exit(0);
		}

		public static void SayHello(MyData data)
		{
			Console.WriteLine("Hello There {0}", data.Name);
		}

		public static int Multiply(int a, int b)
		{
			return a * b;
		}
	}

	public class Countdown
	{
		public int counter { get; set; }

		public event EventHandler AtTheEndEvents;
		public delegate void MyAction(MyData m);			
		public MyAction myAction;


		public Countdown(int counter)
		{
			this.counter = counter;
		}

		public void Decrement()
		{
			counter--;
			if (counter <= 0) 
			{ 
				if (AtTheEndEvents != null) { AtTheEndEvents(this, EventArgs.Empty); } 
			}
			MyData m = new MyData();
			m.Name = "trääääT";
			myAction(m);
		}

		public int Add(int a, int b)
		{
			return a + b;
		}
	}
}
