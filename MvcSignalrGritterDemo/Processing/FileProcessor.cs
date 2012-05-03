using System;
using System.Threading;
using SignalR;
using SignalR.Hosting.AspNet;
using SignalR.Infrastructure;

namespace MvcSignalrGritterDemo.Processing
{
	public class FileProcessor
	{
		public void ProcessFileCallback(object threadContext)
		{
			IConnectionManager connectionManager = AspNetHost.DependencyResolver.Resolve<IConnectionManager>();
			dynamic clients = connectionManager.GetClients<FileUpload>();
			var id = new Random().Next(int.MaxValue);
			var name = String.Format("Test{0}.doc", id);
			Thread.Sleep(2000);
			for (int i = 1; i <= 100; i++ )
			{
				clients.updateProgress(id, name, i);
				Thread.Sleep(500);
			}

			clients.addMessage("Your file upload has finished.");
		}
	}
}