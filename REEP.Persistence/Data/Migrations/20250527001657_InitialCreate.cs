using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REEP.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Parameters = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "date", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ContractTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    TotalDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "date", nullable: false),
                    PossibleRepairTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    MaintenanceTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_MaintenanceTypes_MaintenanceTypeId",
                        column: x => x.MaintenanceTypeId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    FirstPay = table.Column<DateTime>(type: "date", nullable: false),
                    PeriodPay = table.Column<TimeSpan>(type: "interval", nullable: false),
                    LastPay = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    PaymentTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    StatusTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OtherName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OtherContacts = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    SupplierTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_SupplierTypes_SupplierTypeId",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    EquipmentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnicalParameterId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_TechnicalParameters_TechnicalParameterId",
                        column: x => x.TechnicalParameterId,
                        principalTable: "TechnicalParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OtherContacts = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", maxLength: 64, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "date", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ContractId = table.Column<Guid>(type: "uuid", nullable: false),
                    WarrantyTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warranties_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warranties_WarrantyTypes_WarrantyTypeId",
                        column: x => x.WarrantyTypeId,
                        principalTable: "WarrantyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractsAndPayments",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsAndPayments", x => new { x.ContractId, x.PaymentId });
                    table.ForeignKey(
                        name: "FK_ContractsAndPayments_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractsAndPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractsAndSuppliers",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsAndSuppliers", x => new { x.ContractId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ContractsAndSuppliers_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractsAndSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ReceiptedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegistedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    MaintenanceId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApprovedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Maintenances_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Users_CreateByUserId",
                        column: x => x.CreateByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPassports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserUsedId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGrantAccessId = table.Column<Guid>(type: "uuid", nullable: false),
                    WarrantyId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPassports_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentPassports_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentPassports_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentPassports_Users_UserGrantAccessId",
                        column: x => x.UserGrantAccessId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EquipmentPassports_Users_UserUsedId",
                        column: x => x.UserUsedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentPassports_Warranties_WarrantyId",
                        column: x => x.WarrantyId,
                        principalTable: "Warranties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CreatedAt",
                table: "Contracts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DeletedAt",
                table: "Contracts",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EndedAt",
                table: "Contracts",
                column: "EndedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_IsDeleted",
                table: "Contracts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_StartedAt",
                table: "Contracts",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UpdatedAt",
                table: "Contracts",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndPayments_CreatedAt",
                table: "ContractsAndPayments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndPayments_DeletedAt",
                table: "ContractsAndPayments",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndPayments_IsActive",
                table: "ContractsAndPayments",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndPayments_IsDeleted",
                table: "ContractsAndPayments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndPayments_PaymentId",
                table: "ContractsAndPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndPayments_UpdatedAt",
                table: "ContractsAndPayments",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndSuppliers_CreatedAt",
                table: "ContractsAndSuppliers",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndSuppliers_DeletedAt",
                table: "ContractsAndSuppliers",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndSuppliers_IsActive",
                table: "ContractsAndSuppliers",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndSuppliers_IsDeleted",
                table: "ContractsAndSuppliers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndSuppliers_SupplierId",
                table: "ContractsAndSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAndSuppliers_UpdatedAt",
                table: "ContractsAndSuppliers",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_CreatedAt",
                table: "ContractTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_DeletedAt",
                table: "ContractTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_IsDeleted",
                table: "ContractTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_Type",
                table: "ContractTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_UpdatedAt",
                table: "ContractTypes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CreatedAt",
                table: "Equipment",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_DeletedAt",
                table: "Equipment",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeId",
                table: "Equipment",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_IsDeleted",
                table: "Equipment",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Name",
                table: "Equipment",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_TechnicalParameterId",
                table: "Equipment",
                column: "TechnicalParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UpdatedAt",
                table: "Equipment",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_CreatedAt",
                table: "EquipmentPassports",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_DeletedAt",
                table: "EquipmentPassports",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_EquipmentId",
                table: "EquipmentPassports",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_IsDeleted",
                table: "EquipmentPassports",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_LocationId",
                table: "EquipmentPassports",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_Number",
                table: "EquipmentPassports",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_StatusId",
                table: "EquipmentPassports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_UpdatedAt",
                table: "EquipmentPassports",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_UserGrantAccessId",
                table: "EquipmentPassports",
                column: "UserGrantAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_UserUsedId",
                table: "EquipmentPassports",
                column: "UserUsedId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPassports_WarrantyId",
                table: "EquipmentPassports",
                column: "WarrantyId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_CreatedAt",
                table: "EquipmentTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_DeletedAt",
                table: "EquipmentTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_IsDeleted",
                table: "EquipmentTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_Type",
                table: "EquipmentTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_UpdatedAt",
                table: "EquipmentTypes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Address",
                table: "Location",
                column: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreatedAt",
                table: "Location",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DeletedAt",
                table: "Location",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Location_IsDeleted",
                table: "Location",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Name",
                table: "Location",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UpdatedAt",
                table: "Location",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ApprovedByUserId",
                table: "MaintenanceRequests",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_CreateByUserId",
                table: "MaintenanceRequests",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_CreatedAt",
                table: "MaintenanceRequests",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_DeletedAt",
                table: "MaintenanceRequests",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_IsActive",
                table: "MaintenanceRequests",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_IsDeleted",
                table: "MaintenanceRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceId",
                table: "MaintenanceRequests",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ReceiptedAt",
                table: "MaintenanceRequests",
                column: "ReceiptedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_RegistedAt",
                table: "MaintenanceRequests",
                column: "RegistedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_UpdatedAt",
                table: "MaintenanceRequests",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_CreatedAt",
                table: "Maintenances",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_DeletedAt",
                table: "Maintenances",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_EndedAt",
                table: "Maintenances",
                column: "EndedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_IsActive",
                table: "Maintenances",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_IsDeleted",
                table: "Maintenances",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceTypeId",
                table: "Maintenances",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_StartedAt",
                table: "Maintenances",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_UpdatedAt",
                table: "Maintenances",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTypes_CreatedAt",
                table: "MaintenanceTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTypes_DeletedAt",
                table: "MaintenanceTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTypes_IsDeleted",
                table: "MaintenanceTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTypes_Type",
                table: "MaintenanceTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceTypes_UpdatedAt",
                table: "MaintenanceTypes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreatedAt",
                table: "Payments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeletedAt",
                table: "Payments",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FirstPay",
                table: "Payments",
                column: "FirstPay");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IsDeleted",
                table: "Payments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LastPay",
                table: "Payments",
                column: "LastPay");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UpdatedAt",
                table: "Payments",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_CreatedAt",
                table: "PaymentTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_DeletedAt",
                table: "PaymentTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_IsDeleted",
                table: "PaymentTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_Type",
                table: "PaymentTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_UpdatedAt",
                table: "PaymentTypes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Status_CreatedAt",
                table: "Status",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Status_DeletedAt",
                table: "Status",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Status_EndedAt",
                table: "Status",
                column: "EndedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Status_IsActive",
                table: "Status",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Status_IsDeleted",
                table: "Status",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Status_StartedAt",
                table: "Status",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Status_StatusTypeId",
                table: "Status",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_UpdatedAt",
                table: "Status",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_CreatedAt",
                table: "StatusTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_DeletedAt",
                table: "StatusTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_IsDeleted",
                table: "StatusTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_Type",
                table: "StatusTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_UpdatedAt",
                table: "StatusTypes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatedAt",
                table: "Suppliers",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_DeletedAt",
                table: "Suppliers",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Email",
                table: "Suppliers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_IsDeleted",
                table: "Suppliers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UpdatedAt",
                table: "Suppliers",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_CreatedAt",
                table: "SupplierTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_DeletedAt",
                table: "SupplierTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_IsDeleted",
                table: "SupplierTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_Type",
                table: "SupplierTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalParameters_CreatedAt",
                table: "TechnicalParameters",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalParameters_DeletedAt",
                table: "TechnicalParameters",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalParameters_IsDeleted",
                table: "TechnicalParameters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalParameters_Parameters",
                table: "TechnicalParameters",
                column: "Parameters")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalParameters_UpdatedAt",
                table: "TechnicalParameters",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedAt",
                table: "Users",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedAt",
                table: "Users",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                table: "Users",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedAt",
                table: "Users",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_CreatedAt",
                table: "UserTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_DeletedAt",
                table: "UserTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_IsDeleted",
                table: "UserTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_Type",
                table: "UserTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_UpdatedAt",
                table: "UserTypes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_ContractId",
                table: "Warranties",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_CreatedAt",
                table: "Warranties",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_DeletedAt",
                table: "Warranties",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_EndedAt",
                table: "Warranties",
                column: "EndedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_IsDeleted",
                table: "Warranties",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_StartedAt",
                table: "Warranties",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_UpdatedAt",
                table: "Warranties",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_WarrantyTypeId",
                table: "Warranties",
                column: "WarrantyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyTypes_CreatedAt",
                table: "WarrantyTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyTypes_DeletedAt",
                table: "WarrantyTypes",
                column: "DeletedAt");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyTypes_IsDeleted",
                table: "WarrantyTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyTypes_Type",
                table: "WarrantyTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyTypes_UpdatedAt",
                table: "WarrantyTypes",
                column: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractsAndPayments");

            migrationBuilder.DropTable(
                name: "ContractsAndSuppliers");

            migrationBuilder.DropTable(
                name: "EquipmentPassports");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "SupplierTypes");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "TechnicalParameters");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "WarrantyTypes");

            migrationBuilder.DropTable(
                name: "MaintenanceTypes");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "ContractTypes");
        }
    }
}
