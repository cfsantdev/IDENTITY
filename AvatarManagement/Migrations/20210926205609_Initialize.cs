using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvatarManagement.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Avatar",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 26, 17, 56, 8, 893, DateTimeKind.Local).AddTicks(4295)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Src = table.Column<string>(type: "text", nullable: true),
                    W = table.Column<int>(type: "integer", nullable: false),
                    H = table.Column<int>(type: "integer", nullable: false),
                    V = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                });

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
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 26, 17, 56, 8, 891, DateTimeKind.Local).AddTicks(1374)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animation",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AvatarId = table.Column<Guid>(type: "uuid", nullable: false),
                    Src = table.Column<string>(type: "text", nullable: true),
                    IdleStateAnimationTimer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animation_Avatar_AvatarId",
                        column: x => x.AvatarId,
                        principalSchema: "public",
                        principalTable: "Avatar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeRecordTracker",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChangeRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 26, 17, 56, 8, 892, DateTimeKind.Local).AddTicks(5190)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                name: "AnimationState",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnimationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationState_Animation_AnimationId",
                        column: x => x.AnimationId,
                        principalSchema: "public",
                        principalTable: "Animation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimationStateItem",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnimationStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    W = table.Column<int>(type: "integer", nullable: false),
                    H = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationStateItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationStateItem_AnimationState_AnimationStateId",
                        column: x => x.AnimationStateId,
                        principalSchema: "public",
                        principalTable: "AnimationState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Avatar",
                columns: new[] { "Id", "H", "Insertion", "OwnerId", "PublisherId", "Src", "V", "W" },
                values: new object[] { new Guid("d609e9e5-0ce2-4e52-86a8-0fc0455955c7"), 24, new DateTime(2021, 9, 26, 20, 56, 8, 895, DateTimeKind.Utc).AddTicks(9482), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "profile", 1, 14 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Animation",
                columns: new[] { "Id", "AvatarId", "Change", "IdleStateAnimationTimer", "Insertion", "OwnerId", "PublisherId", "Src" },
                values: new object[] { new Guid("9fa06f6c-5525-4fb3-ab0e-3261c8545bdd"), new Guid("d609e9e5-0ce2-4e52-86a8-0fc0455955c7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2021, 9, 26, 20, 56, 8, 898, DateTimeKind.Utc).AddTicks(338), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "profile" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AnimationState",
                columns: new[] { "Id", "AnimationId", "Change", "Index", "Insertion", "Name", "OwnerId", "PublisherId" },
                values: new object[,]
                {
                    { new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new Guid("9fa06f6c-5525-4fb3-ab0e-3261c8545bdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2021, 9, 26, 20, 56, 8, 898, DateTimeKind.Utc).AddTicks(7249), "IDLE", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new Guid("9fa06f6c-5525-4fb3-ab0e-3261c8545bdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 9, 26, 20, 56, 8, 901, DateTimeKind.Utc).AddTicks(7848), "FRONT", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new Guid("9fa06f6c-5525-4fb3-ab0e-3261c8545bdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 9, 26, 20, 56, 8, 903, DateTimeKind.Utc).AddTicks(2488), "BACK", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new Guid("9fa06f6c-5525-4fb3-ab0e-3261c8545bdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 9, 26, 20, 56, 8, 904, DateTimeKind.Utc).AddTicks(7015), "RIGHT", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new Guid("9fa06f6c-5525-4fb3-ab0e-3261c8545bdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 9, 26, 20, 56, 8, 906, DateTimeKind.Utc).AddTicks(1461), "LEFT", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AnimationStateItem",
                columns: new[] { "Id", "AnimationStateId", "Change", "H", "Index", "Insertion", "OwnerId", "PublisherId", "W", "X", "Y" },
                values: new object[,]
                {
                    { new Guid("ba53bf19-8986-48b0-b2b8-398a0ac3604a"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 0, new DateTime(2021, 9, 26, 20, 56, 8, 899, DateTimeKind.Utc).AddTicks(4205), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 20 },
                    { new Guid("ae21cf26-be09-4992-ae5f-e7d002d9f9b5"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, new DateTime(2021, 9, 26, 20, 56, 8, 904, DateTimeKind.Utc).AddTicks(541), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 281, 338 },
                    { new Guid("1809c8e0-3486-4fc9-a082-bf72ceaaab3b"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, new DateTime(2021, 9, 26, 20, 56, 8, 904, DateTimeKind.Utc).AddTicks(2193), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 346, 338 },
                    { new Guid("2a8b3f4f-a566-46de-8405-a6a8781a10a5"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 6, new DateTime(2021, 9, 26, 20, 56, 8, 904, DateTimeKind.Utc).AddTicks(3786), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 410, 338 },
                    { new Guid("e494b591-8e92-4bc2-9fbb-d67ae6bd2c95"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 7, new DateTime(2021, 9, 26, 20, 56, 8, 904, DateTimeKind.Utc).AddTicks(5412), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 474, 338 },
                    { new Guid("de68a979-83f4-4ccc-ac3f-5c018f7ad641"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 0, new DateTime(2021, 9, 26, 20, 56, 8, 904, DateTimeKind.Utc).AddTicks(8612), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 404 },
                    { new Guid("391019ae-3c07-40cd-99b2-6813f517a400"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(266), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 90, 404 },
                    { new Guid("21275474-2e63-4e62-bc6f-0e9d375f378d"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(1858), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 154, 404 },
                    { new Guid("0528dfa5-271c-4475-8a10-b0a908c697fc"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(3442), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 218, 404 },
                    { new Guid("055272cb-2615-4721-be49-149b84ae251c"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, new DateTime(2021, 9, 26, 20, 56, 8, 903, DateTimeKind.Utc).AddTicks(8959), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 218, 338 },
                    { new Guid("dd08ff79-e232-4b73-bc73-1548618544ae"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(5014), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 281, 404 },
                    { new Guid("a4ba807d-e744-4e73-86b3-ec1309de8806"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 6, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(8263), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 410, 404 },
                    { new Guid("7640a2f2-b60b-4127-89bb-db53db2cd82a"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 7, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(9860), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 474, 404 },
                    { new Guid("d45ded90-4089-4211-8fea-63076d65e8af"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 0, new DateTime(2021, 9, 26, 20, 56, 8, 906, DateTimeKind.Utc).AddTicks(3159), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 26, 468 },
                    { new Guid("91ca3ff5-1932-4414-98b5-1cb6c9e73782"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, new DateTime(2021, 9, 26, 20, 56, 8, 906, DateTimeKind.Utc).AddTicks(4818), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 90, 467 },
                    { new Guid("1d3dc136-4cde-4896-bbe9-6ae20a5ee272"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, new DateTime(2021, 9, 26, 20, 56, 8, 906, DateTimeKind.Utc).AddTicks(6423), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 153, 468 },
                    { new Guid("a8e4700e-8d0d-4bcb-9dc8-c91277da4f96"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, new DateTime(2021, 9, 26, 20, 56, 8, 906, DateTimeKind.Utc).AddTicks(8008), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 218, 468 },
                    { new Guid("9728671e-0fed-4216-be4d-a9261c6fdb68"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, new DateTime(2021, 9, 26, 20, 56, 8, 906, DateTimeKind.Utc).AddTicks(9589), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 282, 468 },
                    { new Guid("335735d3-ee1c-46d9-94f1-b2979856bb34"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, new DateTime(2021, 9, 26, 20, 56, 8, 907, DateTimeKind.Utc).AddTicks(1177), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 346, 468 },
                    { new Guid("b81ef14b-d078-4e91-b05d-4e543c7e0104"), new Guid("82b4d763-783b-4021-adca-8006ca1dba9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, new DateTime(2021, 9, 26, 20, 56, 8, 905, DateTimeKind.Utc).AddTicks(6668), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 346, 404 },
                    { new Guid("559cacb0-72e8-41d7-b221-127242ca39bf"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, new DateTime(2021, 9, 26, 20, 56, 8, 903, DateTimeKind.Utc).AddTicks(7346), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 154, 338 },
                    { new Guid("1e497989-da17-4324-afd6-77c5b09b6167"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, new DateTime(2021, 9, 26, 20, 56, 8, 903, DateTimeKind.Utc).AddTicks(5758), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 90, 338 },
                    { new Guid("25f7a155-ec99-4bdb-bc77-fda40502c12a"), new Guid("98bb3714-f46d-47a1-b5d8-804565647227"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 0, new DateTime(2021, 9, 26, 20, 56, 8, 903, DateTimeKind.Utc).AddTicks(4164), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 338 },
                    { new Guid("c6ede385-b310-467c-a89c-68671b29c78c"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, new DateTime(2021, 9, 26, 20, 56, 8, 899, DateTimeKind.Utc).AddTicks(7368), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 82 },
                    { new Guid("28c19f33-30c0-4b52-b5a4-a3165c756559"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, new DateTime(2021, 9, 26, 20, 56, 8, 899, DateTimeKind.Utc).AddTicks(8999), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 148 },
                    { new Guid("151703ff-1ec2-4a26-a2cd-a7865841eef9"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, new DateTime(2021, 9, 26, 20, 56, 8, 900, DateTimeKind.Utc).AddTicks(680), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 212 },
                    { new Guid("d69e5134-ef98-4231-9743-71ee24de5dec"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, new DateTime(2021, 9, 26, 20, 56, 8, 900, DateTimeKind.Utc).AddTicks(2291), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 276 },
                    { new Guid("385cc967-b3c7-40bd-89bc-d251ccad8cbe"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, new DateTime(2021, 9, 26, 20, 56, 8, 900, DateTimeKind.Utc).AddTicks(3900), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 338 },
                    { new Guid("130b1ddd-74a2-4774-b001-9770ef9a0d5e"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 6, new DateTime(2021, 9, 26, 20, 56, 8, 900, DateTimeKind.Utc).AddTicks(5535), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 404 },
                    { new Guid("b7964fb7-4a77-4037-9bc0-fb5ac134adc2"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 7, new DateTime(2021, 9, 26, 20, 56, 8, 900, DateTimeKind.Utc).AddTicks(7582), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 468 },
                    { new Guid("3dea5627-026e-4975-85ed-ea75ccde373b"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 8, new DateTime(2021, 9, 26, 20, 56, 8, 901, DateTimeKind.Utc).AddTicks(246), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 533 },
                    { new Guid("6349d61b-d220-4604-9b3c-17ef175e1eeb"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 9, new DateTime(2021, 9, 26, 20, 56, 8, 901, DateTimeKind.Utc).AddTicks(2905), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 597 },
                    { new Guid("c9ab1500-f3c5-426d-8aeb-b0da09e34254"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 10, new DateTime(2021, 9, 26, 20, 56, 8, 901, DateTimeKind.Utc).AddTicks(4576), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 660 },
                    { new Guid("2395382d-1f60-4296-8615-fff96d4c708b"), new Guid("76897c6a-1fc6-44e0-b426-ab78adbddec0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 11, new DateTime(2021, 9, 26, 20, 56, 8, 901, DateTimeKind.Utc).AddTicks(6196), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 724 },
                    { new Guid("98b482a0-99e1-415a-9061-ac2c7bea60af"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 0, new DateTime(2021, 9, 26, 20, 56, 8, 901, DateTimeKind.Utc).AddTicks(9531), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 25, 275 },
                    { new Guid("dd703caa-2184-4988-8251-5b15fa96c2e3"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, new DateTime(2021, 9, 26, 20, 56, 8, 902, DateTimeKind.Utc).AddTicks(1140), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 90, 275 },
                    { new Guid("d9479124-2d71-4a5f-a6f8-779bd6290a6e"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, new DateTime(2021, 9, 26, 20, 56, 8, 902, DateTimeKind.Utc).AddTicks(2858), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 154, 275 },
                    { new Guid("745c2e34-fe9b-4fdb-9d71-fcf5ed79b48a"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, new DateTime(2021, 9, 26, 20, 56, 8, 902, DateTimeKind.Utc).AddTicks(4451), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 218, 275 },
                    { new Guid("d60aadf5-b15f-440f-ae1e-e79c1c08bb95"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, new DateTime(2021, 9, 26, 20, 56, 8, 902, DateTimeKind.Utc).AddTicks(6125), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 281, 275 },
                    { new Guid("b624fce4-7dcf-4a30-98b3-1404a3abb50b"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, new DateTime(2021, 9, 26, 20, 56, 8, 902, DateTimeKind.Utc).AddTicks(7737), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 345, 275 },
                    { new Guid("f0f2425c-18de-4434-92cc-a7fb82a19741"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 6, new DateTime(2021, 9, 26, 20, 56, 8, 902, DateTimeKind.Utc).AddTicks(9314), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 410, 275 },
                    { new Guid("010c5437-9399-4953-94ce-f25f1c263e7f"), new Guid("4f97aeac-eb45-43ad-8ff6-7b50f76b1114"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 7, new DateTime(2021, 9, 26, 20, 56, 8, 903, DateTimeKind.Utc).AddTicks(899), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 473, 275 },
                    { new Guid("9bb6e0d7-9fdf-4a0b-9005-a014f0eda6de"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 6, new DateTime(2021, 9, 26, 20, 56, 8, 907, DateTimeKind.Utc).AddTicks(2845), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 409, 468 },
                    { new Guid("4e738615-653b-4bf7-bc01-a36c1027c016"), new Guid("c5e30e70-49b3-41dd-8810-c22f7fb65241"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 7, new DateTime(2021, 9, 26, 20, 56, 8, 907, DateTimeKind.Utc).AddTicks(4436), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 14, 474, 468 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animation_AvatarId",
                schema: "public",
                table: "Animation",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationState_AnimationId",
                schema: "public",
                table: "AnimationState",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationStateItem_AnimationStateId",
                schema: "public",
                table: "AnimationStateItem",
                column: "AnimationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeRecordTracker_ChangeRecordId",
                schema: "public",
                table: "ChangeRecordTracker",
                column: "ChangeRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimationStateItem",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ChangeRecordTracker",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AnimationState",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ChangeRecord",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Animation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Avatar",
                schema: "public");
        }
    }
}
