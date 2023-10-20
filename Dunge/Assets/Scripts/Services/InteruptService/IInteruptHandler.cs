using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Services.InteruptService
{
    public interface IInteruptHandler
    {
        public void Interupt();

        public void Continue();
    }
}
