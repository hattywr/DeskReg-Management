//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeskRegMgmtASP
{
    using System;
    using System.Collections.Generic;
    
    public partial class DESKREG_SYSTEMS
    {
        public string AssetID { get; set; }
        public Nullable<int> TYPE_ID { get; set; }
        public Nullable<int> MAKE_ID { get; set; }
        public Nullable<int> MODEL_ID { get; set; }
        public string DISABLED { get; set; }
        public string VLAN { get; set; }
        public string AssetName { get; set; }
        public Nullable<System.DateTime> REG_DATE { get; set; }
        public Nullable<System.DateTime> EXP_DATE { get; set; }
    }
}
