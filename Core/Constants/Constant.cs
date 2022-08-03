using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum  Options
    {
        CreateOwner=1,
        UpdateOwner,
        DeleteOwner,
        GetAll

    }
    public enum Options1
    {
        CreatePharmacy=1,
        UpdatePharmacy,
        DeletePharmacy,
        GetAll,
        GetAllPharmaciesbyOwner,
        Sale
    }
    public enum Options2
    {
        CreateApothecary=1,
        UpdateApothecary,
        DeleteApothecary,
        GetAll,
        GetAllApothecaryByPharmacy,
        Filter

    }
}
