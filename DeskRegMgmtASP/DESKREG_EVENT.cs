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
    
    public partial class DESKREG_EVENT
    {
        public int EVENT_ID { get; set; }
        public Nullable<System.DateTime> EVENT_TIME { get; set; }
        public Nullable<int> ACTION_ID { get; set; }
        public string EVENT_OWNER { get; set; }
        public string EVENT_TARGET { get; set; }
        public string EVENT_FROM { get; set; }
        public string EVENT_TO { get; set; }
    }
}