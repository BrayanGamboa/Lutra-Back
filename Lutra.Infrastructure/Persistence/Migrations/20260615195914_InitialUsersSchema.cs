using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lutra.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialUsersSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE SCHEMA IF NOT EXISTS auth;
                """);

            migrationBuilder.Sql("""
                CREATE TABLE IF NOT EXISTS auth.users (
                    user_id uuid NOT NULL PRIMARY KEY,
                    user_name character varying(50) NOT NULL,
                    email character varying(150) NOT NULL,
                    password_hash character varying(255) NOT NULL,
                    name character varying(100) NOT NULL,
                    lastname character varying(100) NOT NULL,
                    create_at timestamp with time zone NULL,
                    update_at timestamp with time zone NULL,
                    last_login_at timestamp with time zone NULL,
                    is_active boolean NOT NULL
                );
                """);

            migrationBuilder.Sql("""
                CREATE UNIQUE INDEX IF NOT EXISTS "IX_users_email" ON auth.users (email);
                """);

            migrationBuilder.Sql("""
                CREATE UNIQUE INDEX IF NOT EXISTS "IX_users_username" ON auth.users (user_name);
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                DROP TABLE IF EXISTS auth.users;
                """);
        }
    }
}
