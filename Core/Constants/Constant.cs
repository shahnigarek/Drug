using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum  Options
    {
        Exit,
        CreateOwner,
        UpdateOwner,
        DeleteOwner,
        GetAll,

    }
    public enum Options1
    {
        Exit,
        CreatePharmacy,
        UpdatePharmacy,
        DeletePharmacy,
        GetAll,
        GetAllPharmaciesbyOwner,
        Sale,
    }
    public enum Options2
    {
        Exit,
        CreateApothecary,
        UpdateApothecary,
        DeleteApothecary,
        GetAll,
        GetAllApothecaryByPharmacy,
       

    }
    public enum Options3
    {
        Exit,
        CreateMedicine,
        UpdateMedicine,
        DeleteMedicine,
        GetAll,
        GetAllMediciniesByPharmacy,
        Filter,

    }
}
