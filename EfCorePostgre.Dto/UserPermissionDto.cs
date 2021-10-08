namespace EfCorePostgre.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    /// <summary>The user permission.</summary>
    public class UserPermissionDto : AuditDto
    {
        /// <summary>Gets or sets the user ıd.</summary>
        public long UserId { get; set; }

        /// <summary>Gets or sets the user.</summary>
        public virtual UserDto User { get; set; }

        /// <summary>Gets or sets the role ıd.</summary>
        public long PermissionId { get; set; }

        /// <summary>Gets or sets the permission.</summary>
        public virtual PermissionDto Permission { get; set; }
    }
}