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
        GetAll,
        Exit

    }
    public enum Options1
    {
        CreatePharmacy=1,
        UpdatePharmacy,
        DeletePharmacy,
        GetAll,
        GetAllPharmaciesbyOwner,
        Sale,
        Exit
    }
    public enum Options2
    {
        CreateApothecary=1,
        UpdateApothecary,
        DeleteApothecary,
        GetAll,
        GetAllApothecaryByPharmacy,
        Exit
       

    }
    public enum Options3
    {
        CreateMedicine=1,
        UpdateMedicine,
        DeleteMedicine,
        GetAll,
        GetAllMedicineByPharmacy,
        Filter,
        Exit

    }
}
