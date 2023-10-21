using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPNIGHT.Model
{
    internal interface ICrud
    {
        public void Create();
        public void Update();
        public void Read();
        public void Delete();
    }
}
