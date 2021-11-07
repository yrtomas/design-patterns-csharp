<Query Kind="Program" />

void Main()
{
	var payment = new Payment{ Amount = 12, PaymentType = PaymentType.Cash};
	
	var handler = new PaymentValidatorHandler();
	
	handler.SetAndReturnNext(new CashPaymentHandler()).SetAndReturnNext(new CreditCardPaymentHandler());
	
	handler.Handle(payment);
}

public interface IHandler<T> where T : class
{
	void Handle(T request);
	
	IHandler<T> SetAndReturnNext(IHandler<T> next);
}

public abstract class Handler<T> : IHandler<T> where  T : class
{
	public IHandler<T> Next{ get; set; }
	
	public virtual void Handle(T request)
	{
		Next?.Handle(request);
	}
	
	public IHandler<T> SetAndReturnNext(IHandler<T> next)
	{
		Next = next;
		
		return Next;
	}
}

public class PaymentValidatorHandler : Handler<Payment>
{
	public override void Handle(Payment request)
	{
	//if validation fails
		if(false)
			throw new Exception();
			
		
		Next?.Handle(request);
	}
}

public class CashPaymentHandler : Handler<Payment>
{
	public override void Handle(Payment request)
	{
	
		if(request.PaymentType == PaymentType.Cash)
		{
		//Do things
		//Maybe break the chain
		}
		else
		{
			Next?.Handle(request);
		}
	}
}

public class CreditCardPaymentHandler : Handler<Payment>
{
	public override void Handle(Payment request)
	{
	
		if(request.PaymentType == PaymentType.CreditCard)
		{
		//Do things
		//Maybe break the chain
		}
		else
		{
			Next?.Handle(request);
		}
	}
}


public class Payment
{
	public decimal Amount { get; set; }
	
	public PaymentType PaymentType { get; set; }
}

public enum PaymentType
{
	Cash = 1,
	CreditCard,
	DebitCard,
	Check
}