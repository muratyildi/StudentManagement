using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Abstracts
{
    public class EntityBase
    {
        public DateTime CreateDate { get; set; }

        public EntityBase()
        {
            CreateDate = DateTime.UtcNow; //Tüm entity modelleri CreateDate field'ını bu class'dan miras alacaktır.
        }
    }
}
