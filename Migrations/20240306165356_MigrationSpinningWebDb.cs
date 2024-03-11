using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpinningWebApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSpinningWebDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AvailableAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    MainImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => new { x.ProductId, x.SpecificationId });
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionProducts",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionProducts", x => new { x.ProductId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_SessionProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionProducts_UserSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "UserSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("048d205d-9915-45b2-b1a5-1bc3492f778d"), "Силикони" },
                    { new Guid("1622cefc-0438-490d-9d3d-8fa18d6a6cdb"), "Куки" },
                    { new Guid("591f697e-1a88-4600-95f2-8462048bec13"), "Влакна" },
                    { new Guid("9f63652a-fb08-43d0-ac49-a2a281c359f9"), "Макари" },
                    { new Guid("a36b9232-06c7-4376-b949-8b26caded4e2"), "Джиг Глави" },
                    { new Guid("acbd3cde-f96e-4a60-955e-7290a41f155c"), "Въдици" },
                    { new Guid("d8f10838-039f-40f0-b04f-49f7e764ca6f"), "Аксесоари" },
                    { new Guid("e3046b57-b98d-4ab0-9be8-c6a2b010c6a3"), "Блесни" },
                    { new Guid("e4ea4f50-b25a-4bd9-9120-0df23d58a544"), "Воблери" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d236990-57ab-4b2e-a29e-c9db415ea40c"), "Fiiish" },
                    { new Guid("3a77a577-3659-4722-9768-3b001cdcd99b"), "Mepps" },
                    { new Guid("48216279-e574-41c2-b631-f59ab5f07830"), "Jackson" },
                    { new Guid("4fa26fc5-94a9-40fe-a0b3-3f3adbf7b793"), "DAM" },
                    { new Guid("5a47142a-1640-4d1e-bcc3-2bed04110c77"), "Lurefans" },
                    { new Guid("8336b7c5-d582-41b9-b2cb-3021053c7871"), "Ima" },
                    { new Guid("f21230e5-9600-4113-bc2a-18c01affdf26"), "Shimano" },
                    { new Guid("f6a51fbb-359e-4b34-a620-a12e28d5dbe7"), "Last Cast" },
                    { new Guid("fe6692da-6330-4c1a-a5e2-512596cd54a1"), "Savage Gear" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "SpecName" },
                values: new object[,]
                {
                    { new Guid("0cbdb686-255b-49af-bc29-baa847698674"), "Тегло" },
                    { new Guid("1033a627-5da8-487c-9cd9-29a189cf8ca2"), "Вместимост на шпулата" },
                    { new Guid("39bed3aa-f31f-43d9-b7ab-9f6d6e2e0652"), "Окомплектовани с глава и кука" },
                    { new Guid("40cee526-7844-47fe-a8ef-b7a958a08328"), "С резервна шпула" },
                    { new Guid("44af333e-836d-47e0-a952-4bc710084f0e"), "Драг" },
                    { new Guid("4d6bbf88-4575-431a-872f-a59675280416"), "Брой лагери" },
                    { new Guid("51df7fb1-3dbb-404f-83a7-c4ba29924e8a"), "Размер" },
                    { new Guid("58c1801c-9524-4e25-b7da-0fa39bbce408"), "Форма" },
                    { new Guid("8426024c-9b8d-4c17-8aba-272dbf44311b"), "Работен диапазон" },
                    { new Guid("8d177397-c7d2-4295-ba29-6b98eda1993b"), "С тракалка" },
                    { new Guid("a6646f07-e2c1-4d98-9217-84610c559640"), "Дължина" },
                    { new Guid("ae093a3e-1422-4160-91ae-643863ad2cc2"), "Предавателно число" },
                    { new Guid("b4898ce8-8844-4d2f-aa43-8c284320c953"), "Вид риба" },
                    { new Guid("d08a39d1-e733-4d06-ac14-3505297db741"), "Брой секции" },
                    { new Guid("d3984888-6e3d-4a83-ab71-9fffd96b0fe2"), "Тип" },
                    { new Guid("da41d540-1c1d-4f3d-a1ea-c8ab24cde666"), "Транспортна дължина" },
                    { new Guid("ea34b8b1-d49a-426d-825b-f60fd7b81f27"), "Дълбочина на газене" },
                    { new Guid("ec2b5636-feab-48e5-8d4d-407fb00ec11c"), "Вкус и аромат" },
                    { new Guid("f9d7d9c0-4e24-4520-9b66-9307d57dfb95"), "UV/Glow цветове" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableAmount", "CategoryId", "Description", "MainImageURL", "ManufacturerId", "Model", "Price" },
                values: new object[,]
                {
                    { new Guid("3ab3f6d1-f45d-4c80-b9ac-f4cade704097"), 20, new Guid("e4ea4f50-b25a-4bd9-9120-0df23d58a544"), "Brutaliika si e nqa da luja", "https://fishingzone.bg/thumbs/1/2311101433471.jpg", new Guid("48216279-e574-41c2-b631-f59ab5f07830"), "Jester Minnow 78S", 32.899999999999999 },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), 16, new Guid("acbd3cde-f96e-4a60-955e-7290a41f155c"), "Giga ceps vudica", "https://fishingzone.bg/thumbs/1/2312281539051.jpg", new Guid("fe6692da-6330-4c1a-a5e2-512596cd54a1"), "Revenge SG6 Medium Game", 419.0 },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), 12, new Guid("9f63652a-fb08-43d0-ac49-a2a281c359f9"), "Mn qka makara kurti paveta", "https://fishingzone.bg/thumbs/1/2301271942421.jpg", new Guid("f21230e5-9600-4113-bc2a-18c01affdf26"), "Stella FK 4000XG ", 1453.5 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecifications",
                columns: new[] { "ProductId", "SpecificationId", "SpecificationValue" },
                values: new object[,]
                {
                    { new Guid("3ab3f6d1-f45d-4c80-b9ac-f4cade704097"), new Guid("0cbdb686-255b-49af-bc29-baa847698674"), "11.5" },
                    { new Guid("3ab3f6d1-f45d-4c80-b9ac-f4cade704097"), new Guid("a6646f07-e2c1-4d98-9217-84610c559640"), "78" },
                    { new Guid("3ab3f6d1-f45d-4c80-b9ac-f4cade704097"), new Guid("d3984888-6e3d-4a83-ab71-9fffd96b0fe2"), "потъващ" },
                    { new Guid("3ab3f6d1-f45d-4c80-b9ac-f4cade704097"), new Guid("ea34b8b1-d49a-426d-825b-f60fd7b81f27"), "1.0 - 2.0" },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), new Guid("0cbdb686-255b-49af-bc29-baa847698674"), "121" },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), new Guid("8426024c-9b8d-4c17-8aba-272dbf44311b"), "7-25" },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), new Guid("a6646f07-e2c1-4d98-9217-84610c559640"), "2.13" },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), new Guid("b4898ce8-8844-4d2f-aa43-8c284320c953"), "бяла риба, костур, распер" },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), new Guid("d08a39d1-e733-4d06-ac14-3505297db741"), "2" },
                    { new Guid("45b72494-1287-4eb6-b22b-4a672a9bd01c"), new Guid("da41d540-1c1d-4f3d-a1ea-c8ab24cde666"), "110" },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), new Guid("0cbdb686-255b-49af-bc29-baa847698674"), "260" },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), new Guid("40cee526-7844-47fe-a8ef-b7a958a08328"), "Не" },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), new Guid("44af333e-836d-47e0-a952-4bc710084f0e"), "11" },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), new Guid("4d6bbf88-4575-431a-872f-a59675280416"), "12 + 1" },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), new Guid("51df7fb1-3dbb-404f-83a7-c4ba29924e8a"), "4000" },
                    { new Guid("5ad1ea09-52eb-4296-8321-b278b06e920c"), new Guid("ae093a3e-1422-4160-91ae-643863ad2cc2"), "6:2:1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_SpecificationId",
                table: "ProductSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionProducts_SessionId",
                table: "SessionProducts",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "SessionProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
