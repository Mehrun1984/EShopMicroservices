using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BuildingBlocks
{
	public interface ICommand : ICommand<Unit> 
	{
	}
	public interface ICommand<out TResponse> : IRequest<TResponse>
	{
	}
}
