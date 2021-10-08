namespace EfCorePostgre.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    /// <summary>The user role.</summary>
    public class UserRoleDto : AuditDto
    {
        /// <summary>Gets or sets the user ıd.</summary>
        public long UserId { get; set; }

        /// <summary>Gets or sets the user.</summary>
        public virtual UserDto User { get; set; }

        /// <summary>Gets or sets the role ıd.</summary>
        public long RoleId { get; set; }

        /// <summary>Gets or sets the role.</summary>
        [ForeignKey("RoleId")]
        public virtual RoleDto Role { get; set; }
    }
}