<Query Kind="Program" />

void Main()
{
	var context = new OrderingContext();
	Console.WriteLine("Press 1 to create ordering...");
    Console.Read();
}

public class OrderingContext
{
	private IOrderingState state;

	public void TransitionToState(IOrderingState state)
	{
		this.state = state;
		this.state.InitiateState(this);
	}
}

public interface IOrderingState
{
	void InitiateState(OrderingContext orderingContext);
}
public class NewOrder : IOrderingState
{
	public void InitiateState(OrderingContext orderingContext)
	{
		Console.WriteLine("New order created");
		
		orderingContext.TransitionToState(new PendingOrder());
	}
}
public class PendingOrder : IOrderingState
{
	public void InitiateState(OrderingContext orderingContext)
	{
		Console.WriteLine("Pending Order");

	}
}