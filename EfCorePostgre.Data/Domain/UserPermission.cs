namespace EfCorePostgre.Data.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    using EfCorePostgre.Core.Data.Entity;

    /// <summary>The user permission.</summary>
    [Serializable]
    [DataContract]
    [Table("user_permission", Schema = "public")]
    public class UserPermission : AuditEntity
    {
        /// <summary>Gets or sets the user ıd.</summary>
        [DataMember]
        [Column("user_id")]
        public long UserId { get; set; }

        /// <summary>Gets or sets the user.</summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>Gets or sets the role ıd.</summary>
        [DataMember]
        [Column("permission_id")]
        public long PermissionId { get; set; }

        /// <summary>Gets or sets the permission.</summary>
        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
    }
}