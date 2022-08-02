using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum  Options
    {
        CreateOwner,
        UpdateOwner,
        DeleteOwner,
        GetAll

    }
    public enum Options1
    {
        CreatePharmacy,
        UpdatePharmacy,
        DeletePharmacy,
        GetAll,
        GetAllPharmaciesbyOwner,
        Sale
    }
    public enum Options2
    {
        CreateApothecary,
        UpdateApothecary,
        DeleteApothecary,
        GetAll,
        GetAllApothecaryByPharmacy,
        Filter

    }
}
