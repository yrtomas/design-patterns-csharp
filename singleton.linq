<Query Kind="Program" />

void Main()
{
	var service = SingletonService.GetService();
	service.Execute();
}

public class SingletonService
{
	private static SingletonService service;
	private static string mensaje;
	
	private SingletonService()
	{
		mensaje = "I do things";
	}
	public static SingletonService GetService()
	{
		if(service == null)
		{
			return service = new SingletonService();
		}
		return service;
	}
	public void Execute()
	{
		Console.WriteLine(mensaje);
	}
	
}