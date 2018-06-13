using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jacaranda.Entity
{
    public class ErrorLog : BaseEntity
    {
        [MaxLength(200)]
        [Index("IX_ErrorLog_RequestUrl", IsUnique = false, IsClustered = false)]
        public string RequestUrl { get; set; }

        public string RequestBody { get; set; }

        public string Message { get; set; }

        [Required]
        public string StackTrace { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }
    }
}
