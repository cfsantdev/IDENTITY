using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "ChangeRecord",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SerializedPrevious = table.Column<string>(type: "text", nullable: true),
                    SerializedCurrent = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(2621)),
                    Change = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfDigits = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Change = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string[]>(type: "text[]", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    HashAuth = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    Insertion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(4191)),
                    Change = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Change = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeRecordTracker",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChangeRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SerializedPreviousHash = table.Column<string>(type: "text", nullable: true),
                    SerializedCurrentHash = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(3085)),
                    Change = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRecordTracker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeRecordTracker_ChangeRecord_ChangeRecordId",
                        column: x => x.ChangeRecordId,
                        principalSchema: "public",
                        principalTable: "ChangeRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    Insertion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(5506)),
                    Change = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Hash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "public",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "DocumentTypes",
                columns: new[] { "Id", "Change", "Hash", "Insertion", "Name", "NumberOfDigits", "OwnerId", "PublisherId", "State" },
                values: new object[,]
                {
                    { new Guid("011c80a8-7998-41a6-a934-9b9a7959e4f3"), null, "45a83b33ffa6a81f298f0c61116221679a007fefd289959d096aff89b0e97999bfac53cc3596e2716d739ca08ca0b0b0c63b8d6a23f4da12b37f71b1ef287f1f", new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(6434), "CNPJ", 14, new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), new Guid("6d9b54f4-f5bf-412b-aa2a-20b7c24f9ede"), true },
                    { new Guid("782a6bc0-98fb-44f9-acce-d3e33d7314b7"), null, "71398755ecedb397cc5322af263e41a13d499e765a870ceac82278432e00345774a48b1b23f430709b22062297eab2dad353b275a15a976dbb0d71f831962f02", new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(6436), "CNH", 10, new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), new Guid("6d9b54f4-f5bf-412b-aa2a-20b7c24f9ede"), true },
                    { new Guid("b98d98be-885e-4454-8b0e-5c6a29f06df8"), null, "2a2d91ff4e16560d2c0f00730eaa4b1df377ac636fc6a209feeed7f91be53ec88f4fc016bafeccc8a21fedf09a05596a5d27fffc56c3a7e0e9c83948231454e5", new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(6423), "CPF", 11, new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), new Guid("6d9b54f4-f5bf-412b-aa2a-20b7c24f9ede"), true },
                    { new Guid("e6af6086-09e4-4d1f-826a-8f386fbb823e"), null, "7c20402d95f250a8f2a9926cb0bd0199d327f74cf7a1bfe82c17acc29c2f942e101cefc4d1976bee455f6403594ef20b59a989e72abffe0d8e59f20d341abbff", new DateTime(2023, 10, 16, 18, 18, 22, 823, DateTimeKind.Local).AddTicks(6432), "RG", 9, new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), new Guid("6d9b54f4-f5bf-412b-aa2a-20b7c24f9ede"), true }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Profile",
                columns: new[] { "Id", "Email", "Hash", "HashAuth", "Name", "OwnerId", "Password", "PublisherId", "Role" },
                values: new object[,]
                {
                    { new Guid("2ad011a7-0448-4fa0-ac4a-0b0f7b3a736b"), "publisher.rc@gmail.com", "d647cc4eea25c0791249229c6c3e098405a937f9f54c22362d490dbd178f41c98a57360bd6bb005c3f397ae9e88669669b5d6c8a6983954f2e3643feb188e3fc", "QTI5RTdENDFBMkRDQjFDQTk2MTU1NEJFMjkwMTY1MkRFODQzNEI1Q0E3NkMyMUQ2NEE3RkQyMzU1QkU5ODQ5MDlGMEY0MENBQjZFMjQ1MDdEQ0QwQTQ2RUExQjkwRkQ3QzFCQTZENTg2OEYyRTY1NjIxMUFDRTA0QkE0NTg3OTE=", "publisher.rc", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "MDk5MWY5NjAtY2YyNi00MWQ1LWEzZWUtN2Q4YWFhODhiY2Jk", new Guid("fb2dcb04-aca2-4e61-9e87-75683160ff99"), new[] { "PUBLISHER" } },
                    { new Guid("45dc7df1-f19e-4e02-84da-5d3c5ba4de2b"), "publisher.rct@gmail.com", "eea1320abd8ed939999c55d26b2507497aebc2df93a49dfff55f5126d93418e6def2220950a73d3e798442dcdc9ae0cf24922559edd598e172bf433057724f60", "QzY2MzI1REYyM0JBREM4MEY2MEI2OEY4MDU2QjgwRDg4OTI1NzhDNTA4RjczRENDMzI3MDZDN0M1MEI4MjMzMzM0QTBEMjcxRDIyQUMwODMxMDM5NDI4NUVGMDk0MTMxMkFGRTIwMkUxMjUzQTEwMzhCRDVDNkU0MDI3QUIxNTI=", "publisher.rct", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "OWQ5NDk2ZjctYmZjYy00Y2RlLTgwNzQtYzQxNDlmZjllMTc4", new Guid("fb2dcb04-aca2-4e61-9e87-75683160ff99"), new[] { "PUBLISHER" } },
                    { new Guid("6d9b54f4-f5bf-412b-aa2a-20b7c24f9ede"), "publisher.doc.type@gmail.com", "bb7f67f435b7c9bb360af6508a1276f8bf8d9861cf5820c8f459d1c034617ef354d40b88df141f44849517f9f40cdf1836ccea990ba3f19b0c0fe5fa5dab736b", "RjExQjQwNUU3NUIzNDA5QzRBNTY4MDgzNkY1Rjc1Q0FCN0Y4OTNCRDY2NzVFNEZFMzIzRjhBQTYzMzk5OTJBQjA1RDNGNTVCNEI2NzE4Qzg0NUIwMUQ5RDlDMzAwNzMwMzk5RUYyMjdDNTZEQTczNkRCNDE0MTA3MDEzNUFCMDc=", "publisher.doc.type", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "ZmU2OGE1OGUtZWQ4Yi00OTlhLWI5M2ItN2ZiOTA1OWU1MDlk", new Guid("fb2dcb04-aca2-4e61-9e87-75683160ff99"), new[] { "PUBLISHER" } }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Profile",
                columns: new[] { "Id", "Email", "Hash", "HashAuth", "Name", "Password", "Role" },
                values: new object[] { new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "cfs.plus.s8@gmail.com", "63abf25852e5a2fca00e5c846fb7b6dcaa1bd8d90678adf9046fdbb39666250eb3e110fd1fcb415c81eb7bb6c78b58ec03a3721381f68a3f6434c7bb8f0aa416", "MjlEOTJFQkYzQUU1MTFCMkQ0M0Y4MjYwRjFBQUQ1NTA3QjM5MzRDQkY5RkExQzVGQjgwQTAzNDY5RkU4NjIzMjM3NjUxNzQ5MTZBNkRENERDQjMzQkUzQTE1NkEzMTgxM0FGQ0EyRkM0ODY2QTU1N0U5M0QwNUJFQTM2QTQ3OUY=", "admin", "MTIzQGFscGhh", new[] { "ADMIN" } });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Profile",
                columns: new[] { "Id", "Email", "Hash", "HashAuth", "Name", "OwnerId", "Password", "PublisherId", "Role" },
                values: new object[,]
                {
                    { new Guid("d0b5e951-2257-4e2e-8be1-bfa4b2b6b640"), "publisher.doc@gmail.com", "5a8958d3ed78596a9bda88797bebbb43eb2f3abf67ff8dd271750cafffa354be3639c45d26a0d5901a183fbc34648da8f082ac8fc6b0eed033af36b14e324e3c", "MEU3MDQ2QTlCNzIwRDZCREI2MjczMzFDNTdFQjE3MUI1QTdCRjhDMzRGMDQxQTc1OTBDQjQwQzFFRjZFMTFEMEU2RDRGNTI0MzA5REVERkIxOUM3MTU1NTU1NkYxREFBNzU2RDc3MkE4NTEwODc5NTdEQUQzQUI0QzYzRjhCNDQ=", "publisher.doc", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "MmFiY2QwMzItYzg2Yi00N2MyLTljNzMtZDU5NWQxZWIzMzA1", new Guid("fb2dcb04-aca2-4e61-9e87-75683160ff99"), new[] { "PUBLISHER" } },
                    { new Guid("e8b38b60-122b-4e96-8fe2-6b2bc0dbc557"), "publisher.session@gmail.com", "bdeea16a0998befcc15399d72985c5efeea7d630627dbdeb1148cc5686abaf8c531162f48de8f7afadaa6a530ea110c85334da418ed4808013cd4f543c03a676", "Njg4NTk4QTgzNDUwRDQ4MTUyM0IzQjdGNUNERDNCQTUwMDFBM0Q3QTkwNDMyNURBMTcxM0NFRjM2NEU3NjcyNDlCN0ZEMTUyRDFCNTM4NDRFNjg4MkI1NzdCMkJEOURGNENBNDkwREVGNTc0MUU5REIwOTZENTQ3NUU1OTgxQ0U=", "publisher.session", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "ZjIyYThiZWItYTUzOS00ZmQ2LTk1MGEtMDc1NGNhMjkxYWJk", new Guid("fb2dcb04-aca2-4e61-9e87-75683160ff99"), new[] { "PUBLISHER" } },
                    { new Guid("fb2dcb04-aca2-4e61-9e87-75683160ff99"), "publisher.profile@gmail.com", "808a247df9383f79fcf55eccdc4091f9a89a8774783d4e08e5b1db4c9ba21b32da5fd9f8fb7f0508c03496c3269c121aa3e89fc81dd61219a3e42ca423f79e06", "MEM5Q0U3MDVDNjY0MEM3Rjc4QkEwOUVBNkFERUYwQTA2NjBDOENERDJFMzBGREU3OUEzODBBNjI1RjkyNThEM0M2REIxOTA4QjE4Rjk3RThEMDk2RkQ0QjAxRkQxRUI1MzAxNDYyMDJGRjU2RkY0NEE0MjhBRjAxRjNGN0Q2Q0E=", "publisher.profile", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), "ZDZmN2E0YTUtNzY4NC00ZjFhLTk0ZGEtNjczZjU5ZTFhMDI5", new Guid("8d3aa60b-cd64-40f7-ba97-4f4a6a3ba6d2"), new[] { "PUBLISHER" } }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeRecordTracker_ChangeRecordId",
                schema: "public",
                table: "ChangeRecordTracker",
                column: "ChangeRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentTypeId",
                schema: "public",
                table: "Document",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Value",
                schema: "public",
                table: "Document",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Email",
                schema: "public",
                table: "Profile",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Name",
                schema: "public",
                table: "Profile",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeRecordTracker",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ChangeRecord",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "public");
        }
    }
}
