//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiVer1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public long Id { get; set; }
        public long ToUserId { get; set; }
        public System.DateTime NotificationDateTime { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
        public int StatusId { get; set; }
    }
}