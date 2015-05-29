using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateReport
{
    class InspectionField
    {
       public int Device_ID{set; get; }
       public string Feild_1 { set; get; }
        //The other fields
        public InspectionField(int device_id, string feild_1)
        {
            Device_ID = device_id;
            Feild_1 = feild_1;
        }
    }
}
