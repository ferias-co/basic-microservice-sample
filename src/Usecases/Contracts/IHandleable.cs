using System;
using System.Collections.Generic;
using System.Text;

namespace Usecases.Contracts
{
    public interface IHandleable<in TIn, out TOut>
    {

        TOut Handle(TIn input);
    }
}
