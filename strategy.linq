<Query Kind="Program" />

void Main()
{
	Duck riverDuck = new RiverDuck();
	riverDuck.Fly();
}


public class Duck
{
	protected IFlyBehaviour FlyBehaviour;
	
	public void Fly()
	{
		FlyBehaviour.Execute();
	}
}

public class RiverDuck : Duck
{
	public RiverDuck()
	{
		FlyBehaviour = new SlowFlyBehaviour();
	}
}

public interface IFlyBehaviour
{
	void Execute();
}

public class FastFlyBehaviour : IFlyBehaviour
{
	public void Execute()
	{
		Console.WriteLine("I'm flyng fast");
	}
}
public class SlowFlyBehaviour : IFlyBehaviour
{
	public void Execute()
	{
		Console.WriteLine("I'm flyng slow");
	}
}
public class NoFlyBehaviour : IFlyBehaviour
{
	public void Execute()
	{
		Console.WriteLine("I'm not flyng");
	}
}




