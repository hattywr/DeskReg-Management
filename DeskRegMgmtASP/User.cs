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
    
    public partial class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string NickName { get; set; }
        public Nullable<byte> ClassYearID { get; set; }
        public Nullable<byte> GenderID { get; set; }
        public Nullable<byte> SchoolID { get; set; }
        public Nullable<byte> DepartmentID { get; set; }
        public Nullable<short> MajorID { get; set; }
        public Nullable<short> MinorID { get; set; }
        public Nullable<int> AbmID { get; set; }
        public bool RegistrationStatus { get; set; }
        public bool RegistrationPartner { get; set; }
        public bool MascotMailFirstTime { get; set; }
        public bool MascotEmail { get; set; }
        public string POPConfig { get; set; }
        public string WCPassword { get; set; }
        public string Title { get; set; }
        public string SchoolEmail { get; set; }
        public string OtherEmail { get; set; }
        public bool IsSchoolEmailPreferred { get; set; }
        public string PasswordClue { get; set; }
        public string WebSiteTitle { get; set; }
        public string WebSiteURL { get; set; }
        public string ResumeTitle { get; set; }
        public string ResumeURL { get; set; }
        public int PrivateMask { get; set; }
        public byte AddressTypeID { get; set; }
        public bool AutoApproval { get; set; }
        public string MiddleInitial { get; set; }
        public string RegistrationCode { get; set; }
        public System.Guid eCalPassword { get; set; }
        public int CoRegSuccessMask { get; set; }
        public byte[] Timestamps { get; set; }
        public int LoginCnt { get; set; }
        public bool TransferToSchool { get; set; }
        public System.DateTime LastModified { get; set; }
        public int ContestCnt { get; set; }
        public bool ReRegistrationStatus { get; set; }
        public byte ContestSource { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string ParentFName { get; set; }
        public string ParentLName { get; set; }
        public string ParentEMail { get; set; }
        public string UniqueID { get; set; }
    }
}
