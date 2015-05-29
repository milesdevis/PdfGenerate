using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateReport
{
    class InspectionField
    {
       public int Device_ID{set; get; }
        //The other fields
        public InspectionField(int device_id)
        {
            Device_ID = device_id;
        }
    }
}
