using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EfCorePostgre.Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permission_typeId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_userId = table.Column<long>(type: "bigint", nullable: false),
                    created_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_userId = table.Column<long>(type: "bigint", nullable: true),
                    updated_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_userId = table.Column<long>(type: "bigint", nullable: false),
                    created_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_userId = table.Column<long>(type: "bigint", nullable: true),
                    updated_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password_salt = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    is_passwordChangeFirstLogin = table.Column<bool>(type: "boolean", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_permission",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    permission_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_userId = table.Column<long>(type: "bigint", nullable: false),
                    created_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_userId = table.Column<long>(type: "bigint", nullable: true),
                    updated_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_permission_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "public",
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_permission_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_userId = table.Column<long>(type: "bigint", nullable: false),
                    created_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_userId = table.Column<long>(type: "bigint", nullable: true),
                    updated_dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "permission",
                columns: new[] { "id", "created_dateTime", "created_userId", "description", "is_active", "is_deleted", "name", "permission_typeId", "updated_dateTime", "updated_userId" },
                values: new object[] { 1L, new DateTime(2021, 10, 8, 15, 27, 7, 235, DateTimeKind.Utc).AddTicks(2216), 0L, "All Permission For Admin", true, false, "All Permission", 1, null, null });

            migrationBuilder.InsertData(
                schema: "public",
                table: "role",
                columns: new[] { "id", "created_dateTime", "created_userId", "description", "is_active", "is_deleted", "name", "updated_dateTime", "updated_userId" },
                values: new object[] { 1L, new DateTime(2021, 10, 8, 15, 27, 7, 231, DateTimeKind.Utc).AddTicks(8635), 0L, "Admin Role", true, false, "Admin", null, null });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "id", "email", "first_name", "is_active", "is_deleted", "is_passwordChangeFirstLogin", "last_name", "password", "password_salt" },
                values: new object[] { 1L, "yasser021@gmail.com", "Admin", true, false, true, "Admin", "oKCPoRAMbNmNBAb9zmjbX3qMUBVj//jRRR6oBJkQcQMI0hI6kLHZ8KnPazMCgE2yf7oL7SVgH66LIjg7g25baQ==", "QZZ5xsx9Dw0ZArgYbJG9OHGQw58kjcFYiUTOwo61nS9npVE5pWa1X4yuNISoixZSUxgiMbFllZKtxPmXG+IjYQ==" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user_permission",
                columns: new[] { "id", "created_dateTime", "created_userId", "is_active", "is_deleted", "permission_id", "updated_dateTime", "updated_userId", "user_id" },
                values: new object[] { 1L, new DateTime(2021, 10, 8, 15, 27, 7, 253, DateTimeKind.Utc).AddTicks(9122), 0L, true, false, 1L, null, null, 1L });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user_role",
                columns: new[] { "id", "created_dateTime", "created_userId", "is_active", "is_deleted", "role_id", "updated_dateTime", "updated_userId", "user_id" },
                values: new object[] { 1L, new DateTime(2021, 10, 8, 15, 27, 7, 253, DateTimeKind.Utc).AddTicks(5693), 0L, true, false, 1L, null, null, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_permission_id",
                schema: "public",
                table: "user_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_user_id",
                schema: "public",
                table: "user_permission",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                schema: "public",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_user_id",
                schema: "public",
                table: "user_role",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_permission",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "public");

            migrationBuilder.DropTable(
                name: "role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");
        }
    }
}
