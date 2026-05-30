using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BuildingBlocks
{
	public interface IQuery<out TResponse> : IRequest<TResponse>
		where TResponse : notnull
	{
	}
}
