using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.services
{
    public interface ICurrentSession
    {
        int SessionId{ get; }
    }
}